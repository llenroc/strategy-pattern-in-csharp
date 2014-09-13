﻿//Disclaimer:
//This software (or sample code) is not supported under any Microsoft standard support program or service. 
//The software is provided AS IS without warranty of any kind. Microsoft further disclaims all implied 
//warranties including, without limitation, any implied warranties of merchantability or of fitness for 
//a particular purpose. The entire risk arising out of the use or performance of the software and 
//documentation remains with you. In no event shall Microsoft, its authors, or anyone else involved in 
//the creation, production, or delivery of the software be liable for any damages whatsoever (including, 
//without limitation, damages for loss of business profits, business interruption, loss of business 
//information, or other pecuniary loss) arising out of the use of or inability to use the software or 
//documentation, even if Microsoft has been advised of the possibility of such damages.

using BusinessTasks.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTasks.Awesome.Behaviors
{
    public class ValidateOrderBehavior : IValidateOrderBehavior
    {
        public bool validateOrder(object order)
        {
            System.Console.WriteLine("AWESOME CLIENT: Validate Order.");
            return true;
        }
    }
}
