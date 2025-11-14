#!/usr/bin/env sh

set -e 
set -x

until [ ]; do
    dotnet "$1" && break
    sleep 1
done

until [ ]; do
    sleep 30
    curl -f "http://selenium-hub:4444/wd/hub/status" && break
done

dotnet test --logger "console;verbosity=detailed"
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
export PATH="$PATH:/root/.dotnet/tools"
echo "Starting Specflow living doc Report Generation"
livingdoc test-assembly "/src/EATestBDD/bin/Debug/net9.0/EATestBDD.d11" -t "/src/EAT&stBDD/bin/Debug/net9.0/TestExecution.json"