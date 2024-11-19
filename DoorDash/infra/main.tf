provider "aws" {
  region = "eu-central-1"
}

resource "aws_instance" "ecommerce" {
  ami           = "ami-0584590e5f0e97daa"  
  instance_type = "t2.micro"
}
