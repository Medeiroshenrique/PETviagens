
# Building An API 

In this repository I am going to share what I'm learning so that it can be useful for you and me, hope you like this content as much as I am enjoying this learning process :)

## Roadmap

- This API has Create, Read, Update and Delete functions operating with a SQL Server database.

- This code calls other layers to ensure all is organized. All the database stuff are in the layer "Repositorio", witch means Repository in English.

 And, in this case, it lists the passengers registrated by their passage id:

    ```c#
     public Passageiro? Get(long idPassagem) {
            return this.Repositorio.Get(idPassagem);
        }

- It lists all the passengers:
    ```c#
    public List<Passageiro> Listar() {
            return this.Repositorio.Listar();
        }

- This one saves the passenger individually:
    ```c# 
    public Passageiro Salvar(Passageiro passageiro) {
            return this.Repositorio.Salvar(passageiro);
        }
    
- This one updates the passenger by their passage id:
    ```c#
    public Passageiro Atualizar(Passageiro passageiro) {
            Passageiro? p = this.Get((long)passageiro.IdPassagem);
            if (p==null) { 
                throw new Exception(); 
            } else {
                return this.Repositorio.Atualizar(passageiro);
            } 
        }

- Deleting the passenger by their passage id:
    ```c# 
    public bool Excluir(long idPassagem) {
            return this.Repositorio.Excluir(idPassagem);
        }

 
<img src="Screenshot from 2024-07-12 10-58-00.png" alt="banner that says petviajens Building an API ASP.NET">
