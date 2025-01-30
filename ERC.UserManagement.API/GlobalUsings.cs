﻿global using ERC.UserManagement.API;
global using ERC.UserManagement.API.Infrastructure;
global using ERC.UserManagement.API.Routers;
global using ERC.UserManagement.Application;
global using ERC.UserManagement.Application.Common.Exceptions;
global using ERC.UserManagement.Application.Features.Commons;
global using ERC.UserManagement.Application.Features.UserAccounts.Commands;
global using ERC.UserManagement.Application.Features.UserAccounts.Queries;
global using ERC.UserManagement.Core.Models.Options;
global using ERC.UserManagement.Infrastructure;
global using ERC.UserManagement.Infrastructure.Persistence.Database;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.OpenApi.Models;