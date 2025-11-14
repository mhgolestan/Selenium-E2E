#!/usr/bin/env bash

set -e 
set -x

echo "inside waitandrun"

if [ -n "$1" ]; then
    echo "Waiting for the application to be ready..."
    until dotnet "$1"; do
        >&2 echo "Application is not ready yet - sleeping"
        sleep 1
    done
fi

echo "Waiting for Selenium Hub to be ready..."
until curl -sf "http://selenium-hub:4444/wd/hub/status"; do
    >&2 echo "Selenium Hub is not ready yet - sleeping"
    sleep 2
done

# Run tests but continue on failure (|| true) so that the report is always generated.
dotnet test --logger "console;verbosity=detailed"
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
export PATH="$PATH:/root/.dotnet/tools"
echo "Starting Specflow living doc Report Generation"
livingdoc test-assembly "/src/EATestBDD/bin/Debug/net9.0/EATestBDD.dll" -t "/src/EATestBDD/bin/Debug/net9.0/TestExecution.json" 