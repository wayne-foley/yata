#!/bin/bash
echo "Starting API Server on Port 5000"

dotnet watch run --server.urls http://*:5000