 <div align="center">
  <h1>Train Tweaks</h1>
  <p>Uma ferramenta completa para ajustes, manutenção e gerenciamento do Windows.</p>

  <p>
    <img src="https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white" />
    <img src="https://img.shields.io/badge/Language-C%23-68217A?style=for-the-badge&logo=csharp&logoColor=white" />
    <img src="https://img.shields.io/badge/Automation-PowerShell-5391FE?style=for-the-badge&logo=powershell&logoColor=white" />
  </p>
</div>

---

## Sobre o projeto

O **Train Tweaks** é uma ferramenta desenvolvida em C# com foco em otimização, manutenção e personalização do Windows.

O projeto reúne diversas funcionalidades em um único ambiente interativo, permitindo gerenciar configurações do sistema, aplicar ajustes gráficos, configurar prioridades para jogos, executar diagnósticos e realizar tarefas de manutenção.

Todas as operações são executadas individualmente, com apresentação de descrições, avisos e confirmação antes de qualquer alteração.

O programa não aplica otimizações automaticamente ao ser iniciado.

## Funcionalidades

### Windows Tweaks

Conjunto de ajustes para personalizar o comportamento do Windows e gerenciar recursos do sistema.

- Gerenciamento da compressão de memória.
- Ativação e configuração do Modo de Jogo.
- Configurações de Prefetch e SysMain.
- Gerenciamento de aplicativos em segundo plano.
- Ajustes de energia e Power Throttling.
- Configurações de efeitos visuais e transparência.
- Gerenciamento de serviços do Windows.
- Limpeza de arquivos temporários e caches.
- Configurações de telemetria e privacidade.
- Ajustes de escalonamento de tarefas.
- Gerenciamento de recursos Xbox e Game Bar.
- Configurações de hibernação e suspensão USB.
- Reversão de determinados ajustes aplicados.

### GPU Optimization

Perfis específicos para diferentes fabricantes de placas gráficas.

- NVIDIA
- AMD
- Intel
- Reversão das otimizações gráficas aplicadas.

### Game Priority

Sistema de configuração de prioridade para jogos utilizando ajustes no Registro do Windows, através de `Image File Execution Options`.

O catálogo contempla diversos títulos, incluindo:

- Counter-Strike 2
- Valorant
- Fortnite
- Grand Theft Auto V
- FiveM
- Apex Legends
- Rainbow Six Siege
- Call of Duty
- Forza Horizon 4 e 5
- Red Dead Redemption 2
- Minecraft
- League of Legends
- Marvel Rivals
- Rust
- PUBG
- Rocket League
- Assetto Corsa
- Euro Truck Simulator 2
- Elden Ring
- Cyberpunk 2077
- E diversos outros jogos.

A configuração utiliza o valor DWORD `CpuPriorityClass = 3` para os executáveis cadastrados.

### Windows Fixes

Ferramentas de diagnóstico e reparo para problemas comuns do Windows.

- Correção de problemas de áudio e microfone.
- Diagnóstico e reparo de Bluetooth e câmera.
- Reparação de arquivos corrompidos.
- Correção de problemas de rede e DNS.
- Reparação do Windows Update.
- Correção do Windows Search.
- Reparo da Microsoft Store.
- Correção de problemas com impressoras.
- Reinicialização e recuperação do Explorer.
- Diagnóstico de alto uso de CPU e RAM.
- Correção de problemas relacionados ao disco.
- Reparo de componentes e serviços do Windows.
- Correção de problemas com Windows Installer.
- Reparo de aplicativos Xbox.

### System Tools

Ferramentas adicionais para manutenção e gerenciamento do sistema.

- Criação de ponto de restauração.
- Backup de chaves do Registro.
- Liberação de memória RAM.
- Renovação da conexão de rede.
- Limpeza de cache DNS.
- Integração com ferramentas externas, quando disponíveis.

### Auto Cleaner

Sistema de limpeza automática com agendamento semanal pelo Agendador de Tarefas do Windows.

**Principais recursos:**

- Limpeza de arquivos temporários antigos.
- Verificação dos diretórios `%TEMP%` e `C:\Windows\Temp`.
- Exclusão de arquivos com mais de sete dias.
- Proteção contra arquivos em uso ou inacessíveis.
- Execução manual ou agendada.
- Registro das atividades em arquivo de log.
- Instalação e remoção da tarefa pelo próprio aplicativo.

O agendamento não é ativado automaticamente. O usuário escolhe o dia e horário e confirma a instalação.

---

## Segurança e controle

O Train Tweaks foi estruturado para que o usuário tenha controle sobre as alterações realizadas.

- Confirmação antes da execução de cada operação.
- Verificação de privilégios administrativos quando necessário.
- Captura de saída, erros e códigos de retorno.
- Possibilidade de reverter determinados ajustes.
- Criação de ponto de restauração e backup do Registro.
- Avisos específicos para operações que podem afetar o sistema.

## Tecnologias utilizadas

| Tecnologia | Aplicação |
|---|---|
| C# | Desenvolvimento principal |
| .NET | Estrutura da aplicação |
| PowerShell | Execução das operações do Windows |
| Windows Registry | Configuração de parâmetros do sistema |
| Task Scheduler | Agendamento do Auto Cleaner |
| Reflection | Carregamento dinâmico das operações |

## Como funciona

O projeto utiliza uma estrutura baseada em operações independentes, permitindo organizar, carregar e executar funcionalidades individualmente.

**Fluxo de execução:**

1. Inicialização do aplicativo.
2. Carregamento das categorias e operações.
3. Seleção da funcionalidade desejada.
4. Apresentação da descrição e dos avisos.
5. Confirmação do usuário.
6. Execução da operação selecionada.
7. Exibição do resultado e possíveis erros.

## Avisos importantes

Algumas operações modificam serviços, políticas, configurações de segurança e chaves do Registro do Windows.

- Desativar VBS/HVCI reduz proteções de segurança do Windows e pode exigir reinicialização.
- O Debloater pode remover aplicativos utilizados pelo usuário.
- Alterações de rede podem interromper temporariamente a conexão.
- CHKDSK,
