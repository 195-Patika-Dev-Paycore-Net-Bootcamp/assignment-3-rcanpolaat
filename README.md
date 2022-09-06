# assignment-3-rcanpolaat
assignment-3-rcanpolaat created by GitHub Classroom

# 195.Paycore-Net-Bootcamp Week-3 Homework-3

## Homework Details:

A company is working on smart waste collection systems. It is expected that by using a waste collection vehicle in the most optimum and efficient way, it will visit all points and collect waste as soon as possible.

Two SQL tables are used in the system. Container and Vehicle table. While the Vehicle table holds the vehicles that are actively used in the field, the Container table keeps the list of the containers that each of these vehicles should stop by and pick up on that day.

**1-** Fill in these tables to include at least 2 vehicles and 8 random containers for each vehicle.

**2-** Add endpoints that list all the vehicles in the system, add a new vehicle, update and delete vehicle information. (VehicleController)

**3-** Add endpoints that list all the containers in the system, add a new container, update and delete container information. (ContainerController)

**4-** Container and Vehicle relationship will be established from the VehicleId on the container.

**5-** Add a new api and get 2 parameters. Vehicle Id and N(number of clusters). Divide the containers of the vehicle into N clusters with equal elements and prepare all clusters as a single response. (ClusteringController)

**PostgreSql Container Table**
![Ekran Görüntüsü (84)](https://user-images.githubusercontent.com/66038847/188633559-25fb4a5e-c6d1-4a4f-9756-8c04cebab8b6.png)

**PostgreSql Vehicle Table**
![Ekran Görüntüsü (85)](https://user-images.githubusercontent.com/66038847/188633569-5307bc08-68da-417d-8d2b-3d77a2f6697c.png)

**Swagger**
![Ekran Görüntüsü (86)](https://user-images.githubusercontent.com/66038847/188637175-b78c9817-e326-4b79-b8ea-106bc6788853.png)

**Get Containers**
![Ekran Görüntüsü (87)](https://user-images.githubusercontent.com/66038847/188637918-b33d3806-c2f3-49b2-9044-c046c1230cf4.png)

**Post Container**
![Ekran Görüntüsü (88)](https://user-images.githubusercontent.com/66038847/188638047-48b86a7b-e71d-4211-abdd-1c6a261c85e8.png)

**PostgreSql Container Table After Post Container**
![Ekran Görüntüsü (90)](https://user-images.githubusercontent.com/66038847/188638480-a6611291-586e-4c52-a663-88b9a0d4d111.png)

**GetById Container**
![Ekran Görüntüsü (91)](https://user-images.githubusercontent.com/66038847/188638800-3dac9223-e54d-4c34-be0a-2ad157e0cf48.png)

**Get Vehicles**
![Ekran Görüntüsü (92)](https://user-images.githubusercontent.com/66038847/188638989-740b9619-1147-4c05-ab84-ffd6dc08e40d.png)

**This is my code diagram**

![Ekran Görüntüsü (93)](https://user-images.githubusercontent.com/66038847/188639280-26c3451e-0e78-4690-a1e6-53fc0302c531.png)
