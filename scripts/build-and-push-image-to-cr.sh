password=$1
username=lecarvalho
image_name=messenger-api
docker build -t $image_name .
docker tag $image_name $username/$image_name:latest
docker login -u $username -p $password
docker push $username/$image_name:latest