#!/bin/bash

set -e
run_cmd="dotnet CSharpCourse.EmployeesService.Hosting.dll --no-build -v d"
export PATH="$PATH:/root/.dotnet/tools"

dotnet CSharpCourse.EmployeesService.Migrations.dll --no-build -v d -- --dryrun
dotnet CSharpCourse.EmployeesService.Migrations.dll --no-build -v d

>&2 echo "Employee Service DB Migrations complete, starting app."
>&2 echo "Run Employee Service: $run_cmd"
exec $run_cmd
