@echo off
echo Adding logs...
echo 127.0.0.1 chat.openai.com >> C:\Windows\System32\drivers\etc\hosts
echo 127.0.0.1 chatgpt.com >> C:\Windows\System32\drivers\etc\hosts
echo 127.0.0.1 claude.ai >> C:\Windows\System32\drivers\etc\hosts

echo Flushing DNS cache...
ipconfig /flushdns

echo Done.
pause
