using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyThreeNet
{
    public partial class TwentyThree
    {
        /// <summary>
        /// Gets a collection of Flickr Commons institutions.
        /// </summary>
        /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
        public void CommonsGetInstitutionsAsync(Action<TwentyThreeResult<InstitutionCollection>> callback)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("method", "flickr.commons.getInstitutions");

            GetResponseAsync<InstitutionCollection>(parameters, callback);
        }
    }
}
