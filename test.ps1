$network = "prjctr03"

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 10 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 25 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 50 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 100 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 200 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 300 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 400 --content-type "application/json" -f url-list.txt

docker run --name siege --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c 500 --content-type "application/json" -f url-list.txt

