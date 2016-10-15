FROM dotnet 

#Copy CI script
RUN mkdir /root/ci
COPY ci/app.js /root/ci
COPY ci/package.json /root/ci
COPY ci/start.sh /root/ci

#Copy Start script
COPY bujetto-entrypoint.sh /root/
RUN chmod +x /root/bujetto-entrypoint.sh

#dummy DOTNET project
RUN mkdir /root/dummy
WORKDIR /root/dummy
RUN dotnet new
RUN dotnet restore

#Get sources
RUN mkdir /root/git
WORKDIR /root/git
RUN git clone https://github.com/teo-mateo/bujetto.git

#restore dotnet
WORKDIR /root/git/bujetto/bujetto-server/Bujetto.webapi/src/Bujetto.webapi
RUN dotnet restore

#MKDIR output directories
RUN mkdir /root/ci/fe-build

#Install webpack globally
RUN npm install webpack -g

ENV NODE_ENV=production
#Entrypoint: will start listener node app which in turn will start bujetto server
#and will keep it in sync with git (via git hooks)
ENTRYPOINT ["/root/bujetto-entrypoint.sh"]
