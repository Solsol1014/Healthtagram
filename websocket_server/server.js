const WebSocket = require('ws');

const server = new WebSocket.Server({port: 8080});

let clientIdCounter = 0;
const clients = new Map();
const idMap = new Map();

function sendIdToClient(clientId) {
    const clientSocket = clients.get(clientId);
    if (clientSocket && clientSocket.readyState === WebSocket.OPEN) {
        const idMessage = JSON.stringify({type: 'ID', id: `${clientId}`});
        clientSocket.send(idMessage);
        console.log(`Sent message to client ${clientId}: ${idMessage}`);
    }
    else {
        console.log(`Can't find client ${clientId} or it's closed.`);
    }
}

function sendToAll(message) {
    server.clients.forEach(client => {
        if (client.readyState === WebSocket.OPEN) {
            client.send(`${message}`);
        }
    });
}

server.on('connection', socket => {
    const clientId = ++clientIdCounter;
    clients.set(clientId, socket);
    console.log(`Client ${clientId} is connected.`);
    sendIdToClient(clientId);

    socket.on('message', message => {
        const data = JSON.parse(message);

        switch (data.type) {
            case 'ID':
                console.log(`Set ID : ${data.id}`);
                break;

            case 'LogMessage':
                console.log(`From client${data.id}`);
                console.log(`${data.message}`);
                break;

            case 'Emoji':
                console.log(`From client${data.id} : ${data.state}`);
                sendToAll(JSON.stringify(data));
                break;

            case 'Trigger':
                console.log(`Got the Trigger : ${message}`)
                trigger = JSON.parse(message);
                idMap.forEach((value, key) => {
                    const ids = clients.get(Number(key));
                    const putInfo = {};
                    putInfo.id = trigger.id;
                    putInfo.exercise = trigger.exercise;
                    putInfo.body = trigger.body;

                    const puts = {};
                    puts.type = 'Put';
                    const temp = [];
                    temp.push(putInfo);
                    puts.infos = temp;

                    ids.send(JSON.stringify(puts));
                });

                console.log(idMap);
                idMap.set(trigger.id, trigger.body);
                console.log(idMap);
                const clientSocket = clients.get(Number(trigger.id));

                const putList = [];
                const puts = {};
                idMap.forEach((value, key) => {
                    const putInfo = {};
                    putInfo.id = key;
                    putInfo.exercise = 'running';
                    putInfo.body = value;
                    console.log(putInfo);
                    putList.push(putInfo);
                });

                puts.type = 'Put';
                puts.infos = putList;
                clientSocket.send(JSON.stringify(puts));
                break;

            case 'Finish':
                console.log(`Finised client${data.id}`);
                idMap.delete(data.id);
                idMap.forEach((value, key) => {
                    const pop = {};
                    pop.type = 'Pop';
                    pop.id = data.id;

                    const pid = clients.get(Number(key));
                    pid.send(JSON.stringify(pop));
                });
                break;

            default:
                console.log(`Got message from client : ${message}`);
                break;
        }

        // socket.send(`From server - ${message}`);
    });

    socket.on('close', () => {
        idMap.delete(String(clientId));
        idMap.forEach((value, key) => {
            const pop = {};
            pop.type = 'Pop';
            pop.id = clientId;

            const pid = clients.get(Number(key));
            pid.send(JSON.stringify(pop));
        });
        console.log(idMap);
        console.log('Client is disconnected.');
    });
});

console.log('Websocket server is running');