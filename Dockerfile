from docker/whalesay:latest

Run apt-get -y update && apt-get install -y fortunes

CMD /usr/games/fortune -a | cowsay
