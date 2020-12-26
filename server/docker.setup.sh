#!/bin/bash

echo "setting up NADAR.A project locally (server side)"
docker build -t pandologic-server:nadar -f PandoLogic.API/Dockerfile .
