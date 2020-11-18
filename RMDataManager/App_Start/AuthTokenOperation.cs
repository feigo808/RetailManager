using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace RMDataManager.App_Start
{
    public class AuthTokenOperation: IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            // Add a new path to swagger so that we can have our token login screen essentially
            swaggerDoc.paths.Add("/token", new PathItem
            {
                // The command is a post command
                post = new Operation
                {
                    // Put this in 'Auth' catagory
                    tags = new List<string> { "Auth" },
                    // The type of data you're sending the parameters should come through as "application/x-www-form-urlencode"
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencode"
                    },
                    // Definition for the parameters
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type="string",
                            name="grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },
                        new Parameter
                        {
                            type="string",
                            name="username",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type="string",
                            name="password",
                            required = false,
                            @in = "formData"
                        }
                    }
                }
            });
        }
    }
}