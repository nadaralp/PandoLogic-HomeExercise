#!/bin/bash

echo "Setting up NADAR.A project - PandoLogic"
echo "removing network if exists..."

docker-compose down

echo "setting up pando-logic local network"
docker-compose up

echo "setup finished"
start chrome http://localhost:3000
