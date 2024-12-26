# e-commerce

This project is an e-commerce API for integrating delivery services like Walgreens and Hannaford with a scalable backend deployed on AWS.

1. Features:
    - CRUD operations for products, orders, customers, and stores.
    - Containerized architecture with Docker and Docker Compose.
    - Deployed on AWS with Terraform.

2. Prerequisites:
    - Docker
    - Docker Compose
    - .NET SDK
    - Terraform CLI
    - AWS CLI
  
3. Installation and Setup:
   - Download AWS CLI
   - Configure AWS CLI
   - Local setup for the project:
     git clone https://github.com/JoNinna/e-commerce.git
     cd DoorDash/ecommerce
     docker-compose up
   - Download Terraform
   - Configure AWS Credentials for Terraform
   - AWS deployment using Terraform:
     terraform init
     terraform apply

5. Key API endpoints:
   Products:
    GET /products
    POST /products
   Orders:
    GET /orders
    POST /orders
