# More Jeeps

*A simple "game" of counting how many Jeeps you see on a road trip.*

Shortly after my son was born, I purchased a 2 door Jeep Wrangler JK and joined a local jeep club to do a little offroading. With that, there were always jeeps around.  Once he could start talking, my son would say "More Jeeps!" every time he saw one while on a drive.

10 years later, it's now a game we still play in the car, where by the end of the trip, the winner is the person who saw the most number of Jeep Wranglers _first_!

- [More Jeeps](#more-jeeps)
  - [🧩 Set Up](#-set-up)
  - [🫴 Contributing](#-contributing)
    - [Issues](#issues)

## 🧩 Set Up
"More Jeeps" is an Azure Function back end.

*  Get an [Azure](https://azure.microsoft.com/en-us/) subscription. I'm using a _Pay As You Go_ subscription, and the resources I'm using are no cost / low cost (pennies) to operate at the scale I'm operating at.
*  Install [.NET 7.0](https://dotnet.microsoft.com/en-us/)

### 🧱 Terraform
Terraform requires two files now found in source: `backend.conf` and `terraform.tfvars`.

To keep the configuration private, the `backend.conf` should look like this:
```
tenant_id                  = {your Azure tenant ID}
subscription_id            = {your Azure subscription ID}
resource_group_name        = {state file resource group name}
storage_account_name       = {state file storage account name}
container_name             = {state file container name}
key                        = "terraform.tfstate"
```
The variable used to name the resources as a "company code" is stored in `terraform.tfvars`.  This file should look like this:
```
owner_code = "{code}" # this can be _anything_, but recomending a three character acronym

```

## 🫴 Contributing
Contributions are welcome to this repository to make it better.

### Issues
Feel free to submit issues and enhancement requests.