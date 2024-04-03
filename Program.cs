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
        ProductTypeId = 1
    },
    new Product() {
        Name = "Hat",
        Price = 37.50M,
        IsAvailable = true,
        ProductTypeId = 1
    },
    new Product() {
        Name = "Invisibility Potion",
        Price = 179.95M,
        IsAvailable = true,
        ProductTypeId = 2
    },
    new Product() {
        Name = "Luck Potion",
        Price = 340.00M,
        IsAvailable = true,
        ProductTypeId = 2
    },
    new Product() {
        Name = "Blanket of Endless Warmth",
        Price = 219.99M,
        IsAvailable = true,
        ProductTypeId = 3
    },
    new Product() {
        Name = "Self Cleaning Bowl",
        Price = 68.99M,
        IsAvailable = true,
        ProductTypeId = 3
    },
    new Product() {
        Name = "Spruce Wand",
        Price = 439.99M,
        IsAvailable = true,
        ProductTypeId = 4
    },
    new Product() {
        Name = "Oak Wand",
        Price = 475.00M,
        IsAvailable = true,
        ProductTypeId = 4
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
    string productDetailsString = $"{product.Name}, part of the {productTypes[product.ProductTypeId - 1].Name} line that is {(product.IsAvailable ? $"available for ${product.Price}" : "currently unavailable")}";
    return productDetailsString;
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

    Console.WriteLine("What is the name of the product that you would like to add?");
    while (string.IsNullOrWhiteSpace(newProduct.Name)) {
        Console.WriteLine("Product name:");

        try {
            newProduct.Name = Console.ReadLine()!.Trim();
        }
        catch (FormatException) {
            Console.WriteLine("Please input a string!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }
    
    Console.WriteLine("What is its price?");
    while (newProduct.Price == 0.0M) {
        Console.WriteLine("Product price:");

        try {
            newProduct.Price = decimal.Parse(Console.ReadLine()!.Trim());
        }
        catch (FormatException) {
            Console.WriteLine("Please input a decimal!");
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            Console.WriteLine("Something went wrong, please try again!");
        }
    }
    
    Console.WriteLine("What type of product is it?");

    foreach (ProductType productType in productTypes) {
        Console.WriteLine($"{productType.Id}. {productType.Name}");
    }

    while (newProduct.ProductTypeId == 0) {
        Console.WriteLine("Product type:");

        try {
            int productTypeId = int.Parse(Console.ReadLine()!.Trim());
            newProduct.ProductTypeId = productTypes[productTypeId - 1].Id;
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

    products.Add(newProduct);
}

void DeleteProductMenu() {
    throw new NotImplementedException();
}

void UpdateProductMenu() {
    throw new NotImplementedException();
}

