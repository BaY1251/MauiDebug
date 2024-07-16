@echo off
for /f "delims=" %%a in ('dir /ad/s/b .vs') do rd /s /q "%%~a"
for /f "delims=" %%a in ('dir /ad/s/b bin') do rd /s /q "%%~a"
for /f "delims=" %%a in ('dir /ad/s/b obj') do rd /s /q "%%~a"
pause
