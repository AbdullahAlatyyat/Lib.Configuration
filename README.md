# LibConfiguration

Blocks are the like Categorization for the configs
Configurations are basically the properties inside the entities

in short, BlockName must match the EntityName
KeyName in Configurations must match Property Name in Entities

example DB config:
Block
{
"Id": 1,
"Name": "Language",
"Description": "Language block"
}

Configurations
{
"Id": 1,
"BlockId": 1,
"KeyName": "TestInt",
"KeyValue": "512"
}