# Create image ms
docker build -t sample_ms .

# Create container
docker run -d -p 8080:80 --name sample_mscon sample_ms

# Stop container
docker stop sample_mscon

# Remove container
docker rm sample_mscon

# Create image api
docker build -t supermarket_api . 

# Create container
docker run -d -p 5000:5000 --name supermarket_apicon supermarket_api 

# Stop container
docker stop supermarket_apicon

# Remove container
docker rm supermarket_apicon
