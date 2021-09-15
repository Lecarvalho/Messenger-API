registry_url=$1
image_name=$2
docker build -t $image_name .
docker tag $image_name $registry_url/$image_name:latest