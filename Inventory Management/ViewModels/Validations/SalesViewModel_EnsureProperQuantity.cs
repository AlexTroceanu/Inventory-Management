<<<<<<< HEAD
﻿using Inventory_Management.Models;
=======
﻿using UseCases;
>>>>>>> 6979bea (login)
using System.ComponentModel.DataAnnotations;

namespace Inventory_Management.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

<<<<<<< HEAD

            if (salesViewModel != null)
            {
                if(salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("The quantity to sell has to be greater than zero.");
                }
                else
                {
                    var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                    if(product != null)
                    {
                        if (product.Quantity < salesViewModel.QuantityToSell)
                            return new ValidationResult($"{product.Name} only has {product.Quantity} left.");
                    }
                    else
                    {
                        return new ValidationResult("The selected product doesn't exist.");
=======
            if (salesViewModel != null)
            {
                if (salesViewModel.QuantityToSell <= 0)
                {
                    return new ValidationResult("The quantity to sell has to be greater than zero.");
                } else
                {
                    var getProductByIdUseCase = validationContext.GetService(typeof(IViewSelectedProductUseCase)) as IViewSelectedProductUseCase;

                    if (getProductByIdUseCase != null)
                    {
                        var product = getProductByIdUseCase.Execute(salesViewModel.SelectedProductId);
                        if (product != null)
                        {
                            if (product.Quantity < salesViewModel.QuantityToSell)
                                return new ValidationResult($"{product.Name} only has {product.Quantity} left. It is not enough.");
                        } else
                        {
                            return new ValidationResult("The selected product doesn't exist.");
                        }
>>>>>>> 6979bea (login)
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
