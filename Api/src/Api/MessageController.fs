module Api.MessageController

open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks.V2.ContextInsensitive
open Domain.MessageCommands
open MediatR

let CreateMessage : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let! command = ctx.BindJsonAsync<CreateMessageCommand>()
            let mediator = ctx.GetService<IMediator>()
            let! commandResponse = mediator.Send command
            return! ctx.WriteJsonAsync commandResponse.result
        }

let UpdateMessage : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task { return! ctx.WriteJsonAsync "hello" }
