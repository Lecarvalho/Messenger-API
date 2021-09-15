registry_url=$1
username=$2
password=$3
image_name=$4
sh scripts/build-docker-image.sh $registry_url $image_name
sh scripts/push-image-to-cr.sh $registry_url $username $password $image_name