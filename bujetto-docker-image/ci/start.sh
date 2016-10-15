#!/bin/bash

set -x #echo on

#kill all dotnet instances
pidof dotnet | xargs kill -9

#pull
cd /root/git/bujetto
git clean -f
git pull

#fe build
cd /root/git/bujetto/bujetto-client
webpack -p
rm -rf /root/ci/fe-build/*
cp -r /root/git/bujetto/bujetto-client/build/* /root/ci/fe-build

#be build
cd /root/git/bujetto/bujetto-server/Bujetto.webapi/src/Bujetto.webapi

dotnet restore
dotnet build
dotnet run --server.urls=http://*:3000
