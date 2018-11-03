<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.IdentityModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\SMDiagnostics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Internals.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <NuGetReference>Owin.JwtAuth</NuGetReference>
  <Namespace>System.IdentityModel.Tokens</Namespace>
</Query>

var bearerTokenAsString = "";

var tokenHandler = new JwtSecurityTokenHandler();
var token = tokenHandler.ReadToken(bearerTokenAsString);
token.Dump();