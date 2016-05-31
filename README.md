# AtualizarPartialViewComAjax
Usando PartialView e atualizando com Ajax

#Criação do Projeto
 - Criar um projeto MVC5.
 - Incluir um novo Model:
```c#
    public class ModelData
    {
        public DateTime Agora { get; set; }
    }
```
 - Adicionar um novo método ao HomeController:
```c#
  public PartialViewResult EuVouSerAtualizado()
  {
      ModelData m = new ModelData()
      {
          Agora = DateTime.Now
      };
      return PartialView(m);
    }
```
- Clique em cima do nome do metodo do controler e mande adicionar uma view, coloque ele como partial e usando o modelo ModelData, remove o Edit e o Back. Ela ficará assim:
```c#
@model AtualizarPartialViewComAjax.Models.ModelData

<div>
    <h4>ModelData</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.Agora)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.Agora)
        </dd>

    </dl>
</div>
```
 - No final do _Layout adicione o seguinte Script:
 ```c#
     <script type="text/javascript">

        function atualizarDefinicao() {
            $.ajax(
            {
                type: 'GET',
                url: '/Home/EuVouSerAtualizado',
                dataType: 'html',
                cache: false,
                async: true,
                success: function (data) {
                    $('#EuVouSerAtualizado').html(data);
                }
            });
        }

        $("#MeuIDForm").submit(function () {
            atualizarDefinicao();
            event.preventDefault();
        });

        $(document).ready(function () {
            setInterval(atualizarDefinicao, 3000);
        });

    </script>
```
 - Substitua todo o código da pagina Index do controle Home com esse:
 ```c#
 @{
    ViewBag.Title = "Home Page";
}

<div class="row">
    <div class="col-md-4">
        @using (Html.BeginForm("EuVouSerAtualizado", "Home", FormMethod.Post, new {@id="MeuIDForm" }))
        {
        
            <p>
                <div id="EuVouSerAtualizado">
                    @{
            Html.RenderPartial("EuVouSerAtualizado");
        }
                </div>
            </p>
            <input type="submit" value="Atualiza Data" id="AtualizaData" class="btn btn-default" />
        }
        
    </div>
</div>
```
