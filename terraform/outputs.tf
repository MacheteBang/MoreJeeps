output "func" {
  value = {
    name             = azurerm_windows_function_app.func.name
    default_hostname = azurerm_windows_function_app.func.default_hostname
  }
}

output "stapp" {
  value = {
    name = azurerm_static_site.stapp.name

  }
}

output "rg" {
  value = {
    name = azurerm_resource_group.rg.name

  }
}
