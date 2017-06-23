// This is just for testing purposes.
// When okta-test-server is ready, this will be replaced.

const http = require('http')  
const port = 3000

const requestHandler = (request, response) => {  
  console.log(request.url)
  response.end('Hello world')
}

const server = http.createServer(requestHandler)

server.listen(port, (err) => {  
  if (err) {
    return console.log('something bad happened', err)
  }

  console.log(`server is listening on ${port}`)
})

function cleanup() {
  console.log('cleaning up');

  process.exit(1);
}

process.on('exit', cleanup);
process.on('SIGINT', cleanup);
