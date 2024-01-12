Imports System.Text.Json.Serialization
Imports Microsoft.AspNetCore.Authentication.JwtBearer
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.IdentityModel.Tokens
Imports Microsoft.OpenApi.Models
Imports System.Text

Public Module WebApiServiceRegistration
    <System.Runtime.CompilerServices.Extension()>
    Public Function AddWebApiServices(ByVal services As IServiceCollection, ByVal configuration As IConfiguration) As IServiceCollection
        services.AddControllers().AddJsonOptions(Sub(opt) opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)

        services.Configure(Of ApiBehaviorOptions)(Sub(options) options.SuppressModelStateInvalidFilter = True)

        services.AddEndpointsApiExplorer()
        services.AddSwaggerGen(Sub(c)
                                   c.AddSecurityDefinition("Bearer", New OpenApiSecurityScheme() With {
                                       .Description = "JWT Authorization",
                                       .Name = "Authorization",
                                       .In = ParameterLocation.Header,
                                       .Type = SecuritySchemeType.Http,
                                       .Scheme = "Bearer",
                                       .BearerFormat = "JWT"
                                   })

                                   c.AddSecurityRequirement(New OpenApiSecurityRequirement() From {
                                       {
                                           New OpenApiSecurityScheme With {
                                               .Reference = New OpenApiReference With {
                                                   .Type = ReferenceType.SecurityScheme,
                                                   .Id = "Bearer"
                                               }
                                           },
                                           New List(Of String)()
                                       }
                                   })
                               End Sub)

        Return services
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Sub AddAuthServices(ByVal services As IServiceCollection, ByVal configuration As IConfiguration)
        services.AddAuthorization()
        Dim conStr = configuration.GetConnectionString("PurchasingDb")
        Dim tokenOptions = configuration.GetSection("TokenOptions").Get(Of Core.TokenOptions)()

        services.AddAuthentication(Function(options)
                                       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme
                                       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme
                                       options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme
                                   End Function).AddJwtBearer(Function(options)
                                                                  options.TokenValidationParameters = New TokenValidationParameters() With {
                                                                      .ValidateIssuer = True,
                                                                      .ValidateAudience = True,
                                                                      .ValidateLifetime = True,
                                                                      .ValidateIssuerSigningKey = True,
                                                                      .ValidIssuer = tokenOptions.Issuer,
                                                                      .ValidAudience = tokenOptions.Audience,
                                                                      .IssuerSigningKey = New SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                                                                      .ClockSkew = TimeSpan.FromDays(1)
                                                                  }
                                                              End Function)
    End Sub
End Module
