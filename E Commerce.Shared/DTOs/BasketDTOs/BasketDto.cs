using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce.Shared.DTOs.BasketDTOs
{
    public record BasketDto(string Id, ICollection<BasketItemDto> Items);

}

//  | Feature                       | Class |                   Record |
//  | ----------------------- |     --------------------- |     --------------------- |
//  | Equality                      | Reference                 | Value |
//  | Default Mutability            | Mutable                   | Immutable |
//  | Best Use                      | Behavior - rich objects   | Data - carrying objects |
//  | Syntax                        | Longer                    | Shorter(positional) |
//  | Immutability built -in        | No                        | Yes |
//  | With - expression support     | No                        | Yes |




















