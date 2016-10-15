FROM ubuntu

RUN apt-get update
RUN apt-get install -y \
	apt-utils \
	git \
	wget \
	vim \
	curl \
	apt-transport-https 
	

RUN sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
RUN apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
RUN apt-get update
RUN apt-get install -y dotnet-dev-1.0.0-preview2-003131

ENV TERM xterm

#Install node
RUN curl -sL https://deb.nodesource.com/setup_6.x | bash -
RUN apt-get install -y nodejs
