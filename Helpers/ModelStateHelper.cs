using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NET_9_Business_App_MVC_CRUD.Helpers
{
    public class ModelStateHelper
    {
        public static List<string> GetErrors(ModelStateDictionary modelState)
        {
            List<string> errorMessages = new List<string>();
            //step through all the values in ModelState
            foreach (var value  in modelState.Values)
            {
                //if any Errors found, add them to our List
                foreach (var error in value.Errors)
                {
                    errorMessages.Add(error.ErrorMessage);
                }//end Errors scan
            }//end Value scan

            //return all found error messges to the calling Page
            return errorMessages;
        }//end GetErrors()
    }
}
