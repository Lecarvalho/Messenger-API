registry_url=$1
username=$2
password=$3
image_name=$4
docker login $registry_url -u $username -p $password
docker push $registry_url/$image_name:latest