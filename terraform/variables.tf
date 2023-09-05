variable "owner_code" {
  type        = string
  description = "Short (3 character) code defining the owner of the system. Will be used to provision resources."
  nullable    = false
}

variable "dns_zone_name" {
  type        = string
  description = "Root domain relating to the DNS Zone in Azure."
  nullable    = false
}
variable "dns_zone_resource_group_name" {
  type        = string
  description = "Resource group containing the DNS Zone of the root domain."
  nullable    = false
}
