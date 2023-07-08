$concurrencyLevel = 50
$network = "prjctr03"

docker run --rm --network $network -v "$(pwd)/url-list.txt:/url-list.txt" -t yokogawa/siege -b -t 60s -c $concurrencyLevel --content-type "application/json" -f url-list.txt
