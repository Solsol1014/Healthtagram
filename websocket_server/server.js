const WebSocket = require('ws');

const server = new WebSocket.Server({port: 8080});

server.on('connection', socket => {
    console.log('Client is connected.');

    socket.on('message', message => {
        console.log(`Got message from client : ${message}`);

        // socket.send(`From server - ${message}`);

        server.clients.forEach(client => {
            if (client.readyState === WebSocket.OPEN) {
                client.send(`${message}`);
            }
        });
    });

    socket.on('close', () => {
        console.log('Client is disconnected.');
    });
});

console.log('Websocket server is running on ws:///localhost:8080');