#!/bin/bash

set -x #echo on

cd /root/git/bujetto
git pull

cd /root/git/bujetto/bujetto-client
npm install 
webpack -p
rm -rf /root/ci/fe-build/*
cp -r /root/git/bujetto/bujetto-client/build/* /root/ci/fe-build/


cd /root/ci
npm install 
node app
