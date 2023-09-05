resource "azurerm_dns_txt_record" "dns_txt" {
  name                = "@"
  zone_name           = data.azurerm_dns_zone.dns_zone.name
  resource_group_name = data.azurerm_dns_zone.dns_zone.resource_group_name
  ttl                 = 300

  record {
    value = azurerm_static_site_custom_domain.stapp_domain.validation_token == "" ? "validated" : azurerm_static_site_custom_domain.stapp_domain.validation_token
    # Per this open GitHub issue (https://github.com/hashicorp/terraform-provider-azurerm/issues/14750), the
    # validation_token comes back as null once the domain is validated.  The TXT record is no longer needed,
    # but in order to not stop the workflow, the TXT record gets updated to be the word "validated"
  }
}
resource "azurerm_dns_txt_record" "dns_text_record_api" {
  name                = "asuid.api"
  zone_name           = data.azurerm_dns_zone.dns_zone.name
  resource_group_name = data.azurerm_dns_zone.dns_zone.resource_group_name
  ttl                 = 300

  record {
    value = azurerm_windows_function_app.func.custom_domain_verification_id
  }
}
