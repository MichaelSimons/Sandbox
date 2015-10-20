from docker/whalesay:latest

Run apt-get -y update && apt-get install -y fortunes

CMrrorD /usr/games/fortune -a | cowsay

CMD cowsay Hi There!
