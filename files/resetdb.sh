#!/bin/bash
if test -d "Migrations"; then
  rm -rf Migrations
fi
if test -f "project.db"; then
  rm project.db
fi
dotnet ef migrations add InitialCreate
dotnet ef database update
