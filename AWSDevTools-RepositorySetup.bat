@echo off
powershell -noprofile -executionpolicy bypass -Command "& { Import-Module AWSDevTools; Initialize-AWSElasticBeanstalkRepository }"
ping -n 10 127.0.0.1 >nul