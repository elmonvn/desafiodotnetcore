<template>
    <CContainer>
        <CCol sm="8">
            <CCard>
                <CCardHeader><h5><strong>Adicionar Pessoa</strong></h5></CCardHeader>
                <CCardBody>
                    <CForm v-on:submit.prevent="addPessoa">
                        <CRow>
                            <CCol sm="12">
                                <CInput label="Nome" placeholder="Ex: Arístocles Empédocles" required
                                        v-model="pessoa.nome"/>
                            </CCol>
                        </CRow>
                        <CRow>
                            <CCol sm="4">
                                <CInput label="Telefone" placeholder="Ex: (XX) ZZZZZ-ZZZZ" type="tel"
                                        autocomplete="tel" pattern="^\(\d{2}\)\d{5}-\d{4}$"
                                        title="Número de telefone celular" v-model="pessoa.telefone"/>
                            </CCol>
                            <CCol sm="8">
                                <CInput label="E-mail" placeholder="Ex: user@mail.com" type="email"
                                        autocomplete="email" title="Endereço de e-mail pessoal" v-model="pessoa.email"/>
                            </CCol>
                        </CRow>
                        <CRow align-horizontal="center">
                            <CButton type="submit" size="sm" color="primary" value="Add Pessoa">Cadastrar</CButton>
                            <CButton type="reset" size="sm" color="danger">Limpar campos</CButton>
                            <CButton type="button" size="sm" color="secondary">Cancelar</CButton>
                        </CRow>
                    </CForm>
                </CCardBody>
            </CCard>
        </CCol>
    </CContainer>
</template>
<script>
    export default {
        components: {
            name: 'AddPessoa'
        },
        data() {
            return {
                pessoa: {}
            }
        },
        methods: {
            addPessoa() {
                let uri = 'http://localhost:5000/api/pessoas';
                this.axios.post(uri, this.pessoa).then((response) => {
                    console.log(response.data)
                }).catch(e => {
                    console.log(e)
                });
                this.$router.replace('index');
            }
        }
    }
</script>
