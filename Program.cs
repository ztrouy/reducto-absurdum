List<ProductType> productTypes = new List<ProductType>() {
    new ProductType() {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType() {
        Id = 2,
        Name = "Potions"
    },
    new ProductType() {
        Id = 3,
        Name = "Enchanted Objects"
    },
    new ProductType() {
        Id = 4,
        Name = "Wands"
    }
};

List<Product> products = new List<Product>() {
    new Product() {
        Name = "Cloak",
        Price = 79.99M,
        IsAvailable = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2024, 02, 17)
    },
    new Product() {
        Name = "Hat",
        Price = 37.50M,
        IsAvailable = true,
        ProductTypeId = 1,
        DateStocked = new DateTime(2023, 09, 28)
    },
    new Product() {
        Name = "Invisibility Potion",
        Price = 179.95M,
        IsAvailable = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 04, 02)
    },
    new Product() {
        Name = "Luck Potion",
        Price = 340.00M,
        IsAvailable = true,
        ProductTypeId = 2,
        DateStocked = new DateTime(2024, 03, 18)
    },
    new Product() {
        Name = "Blanket of Endless Warmth",
        Price = 219.99M,
        IsAvailable = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2022, 11, 29)
    },
    new Product() {
        Name = "Self Cleaning Bowl",
        Price = 68.99M,
        IsAvailable = true,
        ProductTypeId = 3,
        DateStocked = new DateTime(2024, 01, 05)
    },
    new Product() {
        Name = "Spruce Wand",
        Price = 439.99M,
        IsAvailable = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 02, 19)
    },
    new Product() {
        Name = "Oak Wand",
        Price = 475.00M,
        IsAvailable = true,
        ProductTypeId = 4,
        DateStocked = new DateTime(2024, 02, 19)
    }
};


MainMenu();


void MainMenu() {
    Console.Clear();
    Console.WriteLine("Welcome to Reducto & Absurdum!\n");

    string userChoice = null;
    while (userChoice != "0") {
        Console.WriteLine("Choose an option:");
        Console.WriteLine(@"
        0. Leave
        1. View All Products
        2. Add a Product
        3. Remove a Product
        4. Update a Product
        ");

        userChoice = Console.ReadLine()!.Trim();
        Console.Clear();

        switch (userChoice) {
            case "0":
                Console.WriteLine("Goodbye!");
                break;
            case "1":
                ViewAllProducts();
                break;
            case "2":
                AddProductMenu();
                break;
            case "3":
                DeleteProductMenu();
                break;
            case "4":
                UpdateProductMenu();
                break;
            default:
                Console.WriteLine("Invalid choice selected, please try again!\n");
                break;
        }
    }
}



string ProductDetails(Product product) {
    string productDetailsString = $"{product.Name}, part of the {productTypes[product.ProductTypeId - 1].Name} line that {(product.IsAvailable ? $"has been available at ${product.Price} for {product.DaysOnShelf} days" : "is currently unavailable")}";
    return productDetailsString;
}

void SetProductName(Product product) {
    string currentName = product.Name;
    
    Console.WriteLine("What should the name of this product be?");
    while (product.Name == currentName) {
        Console.WriteLine("Product name:");

        try {
            product.Name = Console.ReadLine()!.Trim();
        }
        catch (FormatException) {
            Console.WriteLine("Please input a string!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }
}

void SetProductPrice(Product product) {
    decimal currentPrice = product.Price;
    
    Console.WriteLine("What is its price?");
    while (product.Price == currentPrice | product.Price == 0.0M) {
        Console.WriteLine("Product price:");

        try {
            product.Price = decimal.Parse(Console.ReadLine()!.Trim());
        }
        catch (FormatException) {
            Console.WriteLine("Please input a decimal!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }
}

void SetProductType(Product product) {
    int currentProductTypeId = product.ProductTypeId;
    
    Console.WriteLine("What type of product should it be?");

    foreach (ProductType productType in productTypes) {
        Console.WriteLine($"{productType.Id}. {productType.Name}");
    }

    while (product.ProductTypeId == 0 | product.ProductTypeId == currentProductTypeId) {
        Console.WriteLine("Product type:");

        try {
            int productTypeId = int.Parse(Console.ReadLine()!.Trim());
            product.ProductTypeId = productTypes[productTypeId - 1].Id;
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please input a valid integer!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }
}

void SetProductAvailability(Product product) {
    Console.WriteLine($"Swapping from {(product.IsAvailable ? "available to not" : "not available to available")}");
    product.IsAvailable = !product.IsAvailable;
}



void ViewAllProducts() {
    Console.WriteLine("Here are all of our products!");
    
    for (int i = 0; i < products.Count; i++) {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }

    Console.WriteLine("");
}

void AddProductMenu() {
    Product newProduct = new Product();
    newProduct.IsAvailable = true;
    newProduct.DateStocked = DateTime.Now;

    SetProductName(newProduct);
    
    SetProductPrice(newProduct);
    
    SetProductType(newProduct);

    products.Add(newProduct);
}

void DeleteProductMenu() {
    ViewAllProducts();

    int chosenProduct = 0;
    Console.WriteLine("Which product would you like to delete?");
    while (chosenProduct == 0) {
        Console.WriteLine("Choose product:");

        try {
            chosenProduct = int.Parse(Console.ReadLine()!.Trim());
            Console.WriteLine($"\nDeleting {products[chosenProduct - 1].Name}...");
            products.RemoveAt(chosenProduct - 1);
            
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose a valid integer!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

}

void UpdateProductMenu() {
    ViewAllProducts();

    Product chosenProduct = null;
    Console.WriteLine("Which product would you like to update?");
    while (chosenProduct == null) {
        Console.WriteLine("Choose product:");

        try {
            int response = int.Parse(Console.ReadLine()!.Trim());
            Console.Clear();
            Console.WriteLine($"You have chosen to edit {products[response - 1].Name}");
            chosenProduct = products[response - 1];
        }
        catch (ArgumentOutOfRangeException) {
            Console.WriteLine("Please choose a valid integer!");
        }
        catch (FormatException) {
            Console.WriteLine("Please input an integer!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }

    string userChoice = null;
    while (userChoice != "0") {
        Console.WriteLine(@$"
    0. Finish editing {chosenProduct.Name}
    1. Edit Name
    2. Edit Price
    3. Edit Product Type
    4. Edit Availability
        ");

        userChoice = Console.ReadLine()!.Trim();
        Console.Clear();

        switch (userChoice) {
            case "0":
                Console.WriteLine("Done editing!");
                break;
            case "1":
                SetProductName(chosenProduct);
                break;
            case "2":
                SetProductPrice(chosenProduct);
                break;
            case "3":
                SetProductType(chosenProduct);
                break;
            case "4":
                SetProductAvailability(chosenProduct);
                break;
            default:
                Console.WriteLine("Invalid choice selected, please try again!\n");
                break;
        }
    }
}

