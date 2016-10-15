var http = require('http');
var stringify = require('json-stringify-safe');
var exec = require('child_process').exec;

const PORT = 82;

var BJ_START_SH = './start.sh'

function handleRequest(request, response){
	
	if(request.url === '/ci' && request.headers['x-github-event'] === 'push'){
		var content = stringify(request, null, 2);
		response.end('CI request accepted. Path hit: ' + request.url);
		console.log('github push event');

		//trigger git pull, build and run
		exec(BJ_START_SH);
		return;
	}

	console.log('random event')
	response.end('It works!! Path hit: ' + request.url);
}

//create the server
var server = http.createServer(handleRequest);

server.listen(PORT, function(){
	console.log('Starting up bujetto server');
	exec(BJ_START_SH);
	console.log('Server listening on '+PORT)
});
