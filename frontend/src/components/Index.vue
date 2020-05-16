<template>
    <CContainer>
        <CCardHeader>
            <h5><strong>Lista de Cadastrados</strong></h5>
        </CCardHeader>
        <CCardBody>
            <CDataTable :items="pessoas" :fields="fields" column-filter table-filter items-per-page-select
                        :items-per-page="5" hover sorter pagination>
                <template #buttons="{pessoa}">
                    <td class="py-2">
                        <CButton color="primary" variant="outline" square size="sm" @click="toUpdatePessoa(pessoa)">
                            Editar
                        </CButton>
                        <CButton color="danger" variant="outline" square size="sm" @click="deletePessoa(pessoa.id)">
                            Remover
                        </CButton>
                    </td>
                </template>
            </CDataTable>
        </CCardBody>
    </CContainer>
</template>
<script>
    const fields = [
        {key: "id", _style: 'width:1%;'},
        {key: 'nome', _style: 'width:40%;'},
        {key: 'telefone', _style: 'width:10%;'},
        {key: 'email', _style: 'width:20%;'},
        {key: 'buttons', label: '', _style: 'width:12%;', sorter: false, filter: false},
    ];

    export default {
        data() {
            return {
                pessoas: [],
                fields
            }
        },
        created: function () {
            this.fetchPessoas();
        },
        methods: {
            fetchPessoas() {
                let uri = 'http://localhost:5000/api/pessoas';
                this.axios.get(uri).then((response) => {
                    this.pessoas = response.data;
                });
            },
            deletePessoa(id) {
                let uri = 'http://localhost:5000/api/pessoas/' + id;
                this.pessoas.splice(id, 1);
                this.axios.delete(uri);
            },
            toUpdatePessoa(pessoa) {
                let uri = 'http://localhost:5000/api/pessoas/' + pessoa.id;
            }
        }
    }
</script>
