USE [SGRC]
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'ASCFG', N'Parámetros del Autoservicio de Citas', N'Parámetros del Autoservicio de Citas', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'BANKS', N'Bancos', N'Listado de Bancos', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'CFGRC', N'Configuración de razones de cancelación', N'Listado de los items necesarios para la configuración de las razones de cancelación, por ejemplo:  máximo de razones a registrar por cita', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'CMBS', N'Opciones de Combos de Motor de Retenciones', N'Opciones de Combos de Motor de Retenciones', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'DAYS', N'Días de la semana', N'Lista donde se almacenaran los días de la semana.', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'DDR', N'Tipo de Dato de Retorno', N'Se refiere al tipo de dato que puede retornar', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'ENC', N'Link para la encuesta', N'Solamente puede haber un item para este catalogo', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'ESTD', N'Estados de las citas', N'Listado de estados de una cita', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'GRPR', N'Agrupamiento de Razones', N'Listado del Agrupamiento de las Razones', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'IDA', N'Identificador Alfabetico', N'Identificador Alfabetico', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'LEY81', N'Configuracion dias Ley 81', N'Configuracion del numero de dias maximo para atencion de Ley 81', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'MRCA', N'Marca de Tarjetas', N'Marca de Tarjetas', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'NDIAS', N'Dias de Semana', N'Dias de las Semana (para horarios)', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'ORGRC', N'Origen de la razón de cancelación', N'Listado del origen de las razones de cancelación registradas en las citas', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'POS', N'Posición', N'Listado de las Posiciones de Atencion para Cada Centro', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'PUBTI', N'Publicidad a mostrar en el ticket', N'Caracteres máximos 50', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'RE', N'Resultado Citas', N'Descripción del resultado de la cita', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'REC', N'Mensaje Recordatorio', N'Solo se tomara el primer valor que contenga esta lista', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'SCHDL', N'Calendario de programación de citas', N'Lista donde se almacenan las configuraciones del calendario usado en la programación de citas', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'SEGM', N'Segmentos', N'Segmentos de Clientes que se pueden atender en los Centros', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'SRC', N'Origen de las Variables', N'Se refiere al origen para obtener el valor de una variable', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'STATS', N'Estado/Situacion', N'Listado de los Estados (Activo/Inactivo)', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TANLD', N'Tipos de Anualidades de Tarjetas ', N'Listado del Tipo de Anualidades de las Tarjetas, eje: Titular o Adicional', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TATEN', N'Tipo de Atencion', N'Tipo de Atencion de las Citas', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TCITA', N'Tipo de cita', N'Listado de tipo de cita', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TEST', N'Catálogo de prueba', N'Este es un catálogo de configuración de prueba', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TFER', N'Tipo de Feriado', N'Tipo de Feriado', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TIPO', N'Tipos de Variables', N'Se refiere a si una variable puede ser de tipo formula o constante', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TMATN', N'Tiempo atención de citas', N'Lista de rangos en minutos del tiempo de atención de citas. Ej. 0-30', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TOOLS', N'Herramientas de Retencion', N'Herramientas de Retencion', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TPOAN', N'Tipo Anualidad', N'Tipos de Anualidades existentes para el motor de retenciones', N'1')
GO
INSERT [dbo].[SGRC_Config] ([ConfigId], [ConfigDescripcion], [ConfigObservacion], [ConfigStatus]) VALUES (N'TRVSN', N'Tipo de Reversiones', N'Tipos de Reversiones existentes para el motor de rentenciones', N'1')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ASCFG', N'CC_MSG', N'Su cita a sido confirmada exitosamente, por favor espere su turno.', N'Mensaje al Confirmar la Cita', N'Mensaje a mostrar en pantalla al confirmar exitosamente una cita', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ASCFG', N'CP_MSG', N'Su cita fue programada exitosamente recuerde llegar a tiempo.', N'Mensaje por pantalla al programar una cita', N'Mensaje a mostrar en pantalla al programarse exitosamente una cita walkin.', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ASCFG', N'CP_MSG_IMP', N'Agradecemos su puntualidad, por favor anunciarse al llegar en la recepción de la sucursal asignada.', N'Mensaje al imprimir el tiquete CP', N'Mensaje al imprimir el tiquete de programar una cita', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ASCFG', N'CW_MSG', N'Su cita fue creado exitosamente tome el tiquete y espere su turno.', N'Mensaje por pantalla al en la Cita WalkIn', N'Mensaje por pantalla al crearse la Cita WalkIn', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ASCFG', N'CW_MSG_IMP', N'Por favor espere su turno.', N'Mensaje en el tiquete impreso Cita WalkIn', N'Mensaje en el tiquete impreso al crearse la Cita WalkIn', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B001', N'Banco General2', N'Banco General', N'Banco General', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B002', N'Banistmo', N'Banistmo', N'Banistmo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B003', N'Scotia Bank', N'Scotia Bank', N'Scotia Bank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B004', N'Banesco', N'Banesco', N'Banesco', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B005', N'St. George', N'St. George', N'St. George', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B006', N'Global Bank', N'Global Bank', N'Global Bank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B007', N'MultiBank', N'MultiBank', N'MultiBank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B008', N'Credicorp', N'Credicorp', N'Credicorp', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B009', N'Bac', N'Bac', N'Bac', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B010', N'Caja De Ahorro', N'Caja De Ahorro', N'Caja De Ahorro', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B011', N'Banco Nacional', N'Banco Nacional', N'Banco Nacional', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B012', N'MetroBank', N'MetroBank', N'MetroBank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B013', N'Capital Bank', N'Capital Bank', N'Capital Bank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B014', N'Lafise', N'Lafise', N'Lafise', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B015', N'Ficohsa', N'Ficohsa', N'Ficohsa', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B016', N'Banisi', N'Banisi', N'Banisi', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B017', N'Banco Panama', N'Banco Panama', N'Banco Panama', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B018', N'Tower Bank', N'Tower Bank', N'Tower Bank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B019', N'Banvivienda', N'Banvivienda', N'Banvivienda', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B020', N'Banco Aliado', N'Banco Aliado', N'Banco Aliado', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B021', N'Canal Bank', N'Canal Bank', N'Canal Bank', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B022', N'Cooperativas', N'Cooperativas', N'Cooperativas', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'B023', N'Financieras', N'Financieras', N'Financieras', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'b100', N'prueba', N'preuba', N'prueba', N'0', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'BANKS', N'bach', N'BAc Honduras', N'BAC Honduras', N'BAc Honduras', N'0', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CFGRC', N'MAXRAZONES', N'Cantidad máxima de razones a registrar', N'2', N'Cantidad máxima de razones a registrar por cita', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CFGRC', N'MINRAZONES', N'Cantidad mínima de razones a registrar', N'1', N'Cantidad mínima de razones a registrar por cita', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CMBS', N'CMBS1', N'Anualidad Titular + Adicional', N'Anualidad Titular + Adicional', N'Anualidad Titular + Adicional', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CMBS', N'CMBS2', N'Anualidad titular + reversión Mora', N'Anualidad titular + reversión Mora', N'Anualidad titular + reversión Mora', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CMBS', N'CMBS3', N'Anualidad titular + reversión SG', N'Anualidad titular + reversión SG', N'Anualidad titular + reversión SG', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CMBS', N'CMBS4', N'Reversión 1 + Reversión 2', N'Reversión 1 + Reversión 2', N'Reversión 1 + Reversión 2', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'CMBS', N'CMBS5', N'Anualidad titular + Tasa', N'Anualidad titular + Tasa', N'Anualidad titular + Tasa', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Domingo', N'Domingo', N'D', NULL, N'1', N'0')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Jueves', N'Jueves', N'J', NULL, N'1', N'4')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Lunes', N'Lunes', N'L', NULL, N'1', N'1')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Martes', N'Martes', N'M', NULL, N'1', N'2')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Miercoles', N'Miércoles', N'MM', NULL, N'0', N'3')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Miércoles', N'Miércoles', N'MM', NULL, N'1', N'3')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Sabado', N'Sábado', N'S', NULL, N'0', N'6')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Sábado', N'Sábado', N'S', NULL, N'1', N'6')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DAYS', N'Viernes', N'Viernes', N'V', NULL, N'1', N'5')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DDR', N'DDR1', N'Tipo de Dato Entero', N'Int', N'Integer', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DDR', N'DDR2', N'Tipo de dato string', N'string', N'String', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DDR', N'DDR3', N'Tipo de dato booleano', N'Bool', N'Bool', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DDR', N'DDR4', N'Tipo de dato decimal', N'Decimal', N'Decimal', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'DDR', N'DDR6', N'Tipo de dato Numerico', N'Numerico', N'Tipo de Dato Numerico', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ENC', N'LINKENCUES', N'LINKS PARA LAS ENCUENTAS', N'www.sucursalelectronica.com', N'SOLO DEBE HABER UN ITEMS PARA ESTE CATALAGO', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ESTD', N'1', N'Cita Programada', N'Programada', N'Cita Programada', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ESTD', N'2', N'Cliente llegó a la agencia', N'Cliente en agencia', N'Cliente está en agencia', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ESTD', N'3', N'Cliente en proceso', N'Cliente en proceso', N'Cliente es atendido en la agencia', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ESTD', N'4', N'Cliente fue atendido', N'Cliente fue atendido', N'Cliente fue atendido en la agencia', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ESTD', N'5', N'Cita abandonada', N'Abandonada', N'Cliente abandona la agencia', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ESTD', N'6', N'Cita Cancelada', N'Cancelada', N'Cita cancelada por algún motivo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'GRPR', N'INVL', N'Involuntario', N'Involuntario', N'Agrupamiento de Razones Involuntarias', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'GRPR', N'PROC', N'Proceso', N'Proceso', N'Agrupamiento de Razones por Proceso', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'GRPR', N'VLNT', N'Voluntario', N'Voluntario', N'Agrupamiento de Razones Voluntarias', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'A', N'A', N'A', N'A', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'B', N'B', N'B', N'B', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'C', N'C', N'C', N'C', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'D', N'D', N'D', N'D', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'E', N'E', N'E', N'E', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'F', N'F', N'F', N'F', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'G', N'G', N'G', N'G', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'H', N'H', N'H', N'H', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'I', N'I', N'I', N'I', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'J', N'J', N'J', N'J', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'K', N'K', N'K', N'K', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'L', N'L', N'L', N'L', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'M', N'M', N'M', N'M', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'N', N'N', N'N', N'N', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'O', N'O', N'O', N'O', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'P', N'P', N'P', N'P', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'Q', N'Q', N'Q', N'Q', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'R', N'R', N'R', N'R', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'S', N'S', N'S', N'S', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'T', N'T', N'T', N'T', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'U', N'U', N'U', N'U', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'V', N'V', N'V', N'V', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'W', N'W', N'W', N'W', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'X', N'X', N'X', N'X', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'Y', N'Y', N'Y', N'Y', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'IDA', N'Z', N'Z', N'Z', N'Z', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'LEY81', N'LEY81', N'5', N'5', N'Dias maximos de atencion por Ley 81', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'MRCA', N'-1', N'No definida', N'N/D', N'Tarjeta no definida', N'0', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'MRCA', N'AM', N'American Express', N'AMEX', N'American Express', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'MRCA', N'MC', N'MasterCard', N'MC', N'MasterCard', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'MRCA', N'OT', N'Otras', N'OTRAS', N'Otras', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'MRCA', N'TR', N'Trade', N'TRADE', N'Trade', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'MRCA', N'VS', N'Visa', N'VISA', N'Visa', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'1', N'Lunes', N'Lunes', N'Lunes', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'2', N'Martes', N'Martes', N'Martes', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'3', N'Miércoles', N'Miércoles', N'Miércoles', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'4', N'Jueves', N'Jueves', N'Jueves', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'5', N'Viernes', N'Viernes', N'Viernes', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'6', N'Sábado', N'Sábado', N'Sábado', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'NDIAS', N'7', N'Domingo', N'Domingo', N'Domingo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ORGRC', N'A', N'Atención de la cita', N'Desde atención', N'Razón registrada desde atención de citas', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'ORGRC', N'P', N'Programación de la cita', N'Desde Programación', N'Razón registrada desde programación de citas', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'ANONYMOUS1', N'Posición 2 de bienvenida', N'ANON01', N'Segundo cubículo de tipo bienvenida', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'ANONYMOUSP', N'Posición de bienvenida', N'ANON00', N'Posición de bienvenida', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'C01', N'Cabina 01', N'C01', N'Cabina 01', N'1', N'0')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'DISPLAY01', N'DISPLAY DE AGENCIAS', N'DSPL01', N'DISPLAY DE AGENCIAS', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'DISPLAY02', N'DISPLAY DE AGENCIAS 02', N'DSPL02', N'DISPLAY DE AGENCIAS 02', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E01', N'Escritorio 01', N'E01', N'Escritorio 01', N'1', N'1')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E02', N'Escritorio 02', N'E02', N'Escritorio 02', N'1', N'2')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E03', N'Escritorio 03', N'E03', N'Escritorio 03', N'1', N'3')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E04', N'Escritorio 04', N'E04', N'Escritorio 04', N'1', N'4')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E05', N'Escritorio 05', N'E05', N'Escritorio 05', N'1', N'5')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E06', N'Escritorio 06', N'E06', N'Escritorio 06', N'1', N'6')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E07', N'Escritorio 07', N'E07', N'Escritorio 07', N'1', N'7')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E08', N'Escritorio 08', N'E08', N'Escritorio 08', N'1', N'8')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E09', N'Escritorio 09', N'E09', N'Escritorio 09', N'1', N'9')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E10', N'Escritorio 10', N'E10', N'Escritorio 10', N'1', N'10')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E11', N'Escritorio 11', N'E11', N'Escritorio 11', N'1', N'11')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E12', N'Escritorio 12', N'E12', N'Escritorio 12', N'1', N'12')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E13', N'Escritorio 13', N'E13', N'Escritorio 13', N'1', N'13')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E14', N'Escritorio 14', N'E14', N'Escritorio 14', N'1', N'14')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'E15', N'Escritorio 15', N'E15', N'Escritorio 15', N'1', N'15')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'PRGCITAS01', N'PROGRAMADOR DE CITAS 01', N'PRG01', N'PROGRAMADOR DE CITAS 01', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'PRGCITAS02', N'PROGRAMADOR DE CITAS 02', N'PRG02', N'PROGRAMADOR DE CITAS 02', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'V01', N'Ventanilla 01', N'V01', N'Ventanilla 01', N'1', N'16')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'V02', N'Ventanilla 02', N'V02', N'Ventanilla 02', N'1', N'17')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'V03', N'Ventanilla 03', N'V03', N'Ventanilla 03', N'0', N'18')
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'WELCOME01', N'OFICIAL DE BIENVENIDA 01', N'WLCM01', N'OFICIAL DE BIENVENIDA 01', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'POS', N'WELCOME02', N'OFICIAL DE BIENVENIDA 02', N'WLCM02', N'OFICIAL DE BIENVENIDA 02', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'PUBTI', N'PUBTI1', N'descripicion', N'abreviatura', N'onbservacion', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'RE', N'RE01', N'Retenido', N'RE01', N'primer item del resultado', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'RE', N'RE02', N'No Retenido', N'RE02', N'2do item del resultado', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'REC', N'RECMGS', N'BAC Credomatic le recuerda que se ha tiene una cita programada para el día de hoy.', N'MGS', N'Mensaje de correo automático para el recordatorio de las citas del cliente.', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SCHDL', N'MAXDATE', N'Fecha máxima de aceptación de citas - Horizonte de citas', N'14', N'Item encargado de definir el la fecha máxima de aceptacion de citas u horizonte de programación de citas, dentro del calendario. Definido en días.', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SCHDL', N'MINTIME', N'Hora Inicio de Calendario', N'06:00:00', N'Item encargado de definir el inicio del calendario. Definido en tiempo de 24 de horas. Ejemplo 07:00:00 equivale a 07:00:00  am', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SCHDL', N'SLOTDURAT', N'Intervalo de separación de tiempo del calendario', N'00:15:00', N'Item encargado de definir la separación de tiempo del calendario. Definido en minutos. Ejemplo 00:15:00 equivale a 15 minutos', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'BLCK', N'Segmento BLACK', N'BLACK', N'Sgmt BLACK', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'BSNS', N'Sgmt BUSINESS', N'BUSINESS', N'Sgmt BUSINESS', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'CLSC', N'Sgmt CLASICO', N'CLASICO', N'Sgmt CLASICO', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'CRPT', N'Sgmt CORPORATE', N'CORPORATE', N'Sgmt CORPORATE', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'DEBT', N'Sgmt DEBITO', N'DEBITO', N'Sgmt DEBITO', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'DEMP', N'Sgmt DEPOSITO EMPRESARIAL', N'DEP.EMP', N'Sgmt DEPOSITO EMPRESARIAL', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'DRDO', N'Sgmt DORADO', N'DORADO', N'Sgmt DORADO', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'FLTA', N'Sgmt FLOTA', N'FLOTA', N'Sgmt FLOTA', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'PLTN', N'Sgmt PLATINO', N'PLATINO', N'Sgmt PLATINO', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'PRPG', N'Sgmt PREPAGADO', N'PREPAGADO', N'Sgmt PREPAGADO', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SEGM', N'TRDE', N'Sgmt TRADE', N'TRADE', N'Sgmt TRADE', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SRC', N'SRC1', N'Web Service externo BAC', N'Web Service', N'este origen se dara a las variables obtenidas del webservice externo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'SRC', N'SRC2', N'Motor de Retenciones', N'MTRDRTCN', N'Variables propias del motor de retencion ya sean calculadas o constantes', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'STATS', N'ACT', N'Activo', N'ACT', N'Activo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'STATS', N'BAJ', N'De Baja', N'BAJ', N'De Baja', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'STATS', N'NCT', N'Inactivo', N'INACT', N'Inactivo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TANLD', N'TANLD1', N'Tipo de Anualidad Titular', N'Titular', N'Tipo de Anualidad Titular', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TANLD', N'TANLD2', N'Tipo de Anualidad Adicional', N'Adicional', N'Tipo de Anualidad Adicional', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TATEN', N'BIENVENIDA', N'Bienvenida', N'Bienvenida', N'Bienvenida', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TATEN', N'DISPLAY', N'DISPLAY', N'DSPL', N'DISPLAY', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TATEN', N'P&WI', N'Programada y Walk In', N'Prg&WIn', N'Programada y Walk In', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TATEN', N'PRGCITAS', N'PROGRAMADOR CITAS', N'PRG', N'PROGRAMADOR CITAS', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TATEN', N'PROG', N'Programada', N'Prog', N'Programada', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TATEN', N'WALK', N'Walk In', N'W-In', N'Walk In', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TCITA', N'0', N'Cita Programada', N'Prog', N'Programada', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TCITA', N'1', N'Cita Walk-In', N'WLK', N'Walk-In', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TEST', N'TEST1', N'Elemento de prueba', N'TEST1', N'Este es un elemento de prueba dentro de la catálogo de Prueba', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TFER', N'FERDP', N'F. Dia Parcial', N'Feriado de Dia Parcial', N'Feriado de Dia Parcial', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TFER', N'FERDT', N'F. Dia Completo', N'Feriado de Dia Completo', N'Feriado de Dia Completo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TIPO', N'TIPO1', N'Constante', N'Constante', N'Variable de Tipo Constante', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TIPO', N'TIPO2', N'Formula', N'Formula', N'Variable de Tipo Formula', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TMATN', N'R1', N'De 0 a 15 minutos', N'0-15', N'De 0 a 15 minutos', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TMATN', N'R2', N'De 15 a 30 minutos', N'15-30', N'De 15 a 30 minutos', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TMATN', N'R3', N'De 30 a 40 minutos', N'30-40', N'De 30 a 40 minutos', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TMATN', N'R4', N'De 40 a 60 minutos', N'40-60', N'De 40 a 60 minutos', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TMATN', N'R5', N'Mas de 60 minutos', N'60...', N'Mas de 60 minutos', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TOOLS', N'T001', N'Eliminar intereses moratorios', N'Int. Mora', N'Eliminar intereses moratorios', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TOOLS', N'T002', N'Disminuir tasa de interes', N'- Tasa Int.', N'Disminuir tasa de interes', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TOOLS', N'T003', N'Otorgar milleje extra', N'+ Millas', N'Otorgar milleje extra', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TPOAN', N'TPOAN1', N'Tipo de Anualidad del Titular', N'Titular', N'Tipo de Anualidad del Titular', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TPOAN', N'TPOAN2', N'Tipo de Anualidad de Tarjetas Adicionales', N'Adicional', N'Tipo de Anualidad de Tarjetas Adicionales', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN1', N'COM Informa', N'COM Informa', N'COM Informa', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN10', N'Cargo Retiro Efectivo', N'Cargo Retiro Efectivo', N'Cargo Retiro Efectivo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN2', N'Mora', N'Mora', N'Mora', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN3', N'SG', N'SG', N'SG', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN4', N'Ret. EC', N'Ret. EC', N'Ret. EC', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN5', N'Cargo Compra de Saldo', N'Cargo Compra de Saldo', N'Cargo Compra de Saldo', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN6', N'Cargo Tasa Cero', N'Cargo Tasa Cero', N'Cargo Tasa Cero', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN7', N'Rep. X Deterioro', N'Rep. X Deterioro', N'Rep. X Deterioro', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN8', N'Anualidad Diferida', N'Anualidad Diferida', N'Anualidad Diferida', N'1', NULL)
GO
INSERT [dbo].[SGRC_ConfigItem] ([ConfigId], [ConfigItemId], [ConfigItemDescripcion], [ConfigItemAbreviatura], [ConfigItemObservacion], [ConfigItemStatus], [ConfigItemOrden]) VALUES (N'TRVSN', N'TRVSN9', N'Reversion RPF', N'Reversion RPF', N'Reversion RPF', N'1', NULL)
GO
INSERT [dbo].[SGRC_Funciones] ([FuncionCodigo], [FuncionNombre], [FuncionNumeroParametros], [FuncionTipoDeRetorno], [FuncionDescripcion], [ConfigId]) VALUES (N'FRCNCY', N'Frecuencia', 2, N'DDR1', N'Esta función devuelve si la fecha del cargo se encuentra dentro del rango aceptado o no. Puede recibir 1 o 2 paramtros', N'DDR')
GO
INSERT [dbo].[SGRC_Reclamos] ([ReclamoId], [ReclamoNombre], [ReclamoDescripcion]) VALUES (N'001', N'Anualidad', N'Reclamos por anualidades de tarjetas')
GO
INSERT [dbo].[SGRC_Reclamos] ([ReclamoId], [ReclamoNombre], [ReclamoDescripcion]) VALUES (N'002', N'Reversion', N'Reclamos por reversion de cobros no realizados por el tarjeta habiente')
GO
INSERT [dbo].[SGRC_Reclamos] ([ReclamoId], [ReclamoNombre], [ReclamoDescripcion]) VALUES (N'003', N'Tasas', N'Evaluacion de Tasas Anualizadas')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'001', N'Anualidad Titular 100% - Black')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'002', N'Anualidad Titular 100% - Platino')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'003', N'Anualidad Titular 100% - Dorada')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'004', N'Anualidad Titular 100% - Clasico')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'005', N'Anualidad Titular 100% - Business')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'006', N'Anualidad Titular 75%-Black')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'007', N'Anualidad Titular 75%-Dorado')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'008', N'Anualidad Titular 75%-Platino')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'009', N'Anualidad Titular 75%-Clasico')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'010', N'Anualidad Titular 75%-Business')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'011', N'Anualidad Titular 50%-Black')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'012', N'Anualidad Titular 50%-Platino')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'013', N'Anualidad Titular 50%-Dorado')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'014', N'Anualidad Titular 50%-Clasico')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'015', N'Anualidad Titular 50%-Business')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'016', N'Anualidad Adicional 100%-Black')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'017', N'Anualidad Adicional 100%-Platino')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'018', N'Anualidad Adicional 100%-Dorado')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'019', N'Anualidad Adicional 100%-Clasico')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'001', N'020', N'Anualidad Adicional 100%-Business')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'001', N'COM Informa (3 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'002', N'Mora (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'003', N'SG (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'004', N'Ret. EC (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'005', N'Cargo Compra de saldo (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'006', N'Cargo Tasa cero (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'007', N'Rep. X Deterioro (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'008', N'Anualidad Diferida (2 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'009', N'Rversion PRF (3 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'002', N'010', N'Cargo Retiro Efectivo (1 en 6 meses)')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'001', N'Tasa Clasico 24% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'002', N'Tasa Clasico 19.68% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'003', N'Tasa Dorado 21.96% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'004', N'Tasa Dorado 20.88% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'005', N'Tasa Platino 18.48% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'006', N'Tasa Platino 13.92% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'007', N'Tasa Black 13.92% Anual')
GO
INSERT [dbo].[SGRC_ItemsDeReclamos] ([ReclamoId], [ItemDeReclamoId], [ItemDeReclamoDescripcion]) VALUES (N'003', N'008', N'Tasa Business 20.88% Anual')
GO
SET IDENTITY_INSERT [dbo].[SGRC_Parametros] ON 
GO
INSERT [dbo].[SGRC_Parametros] ([ParametroId], [ParametroName], [TipoId], [FuncionCodigo], [ConfigID]) VALUES (39, N'FechaCargo1', N'DDR3', N'FRCNCY', N'DDR')
GO
INSERT [dbo].[SGRC_Parametros] ([ParametroId], [ParametroName], [TipoId], [FuncionCodigo], [ConfigID]) VALUES (40, N'FechaCargo2', N'DDR3', N'FRCNCY', N'DDR')
GO
SET IDENTITY_INSERT [dbo].[SGRC_Parametros] OFF
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'ANTGD', N'Antiguedad', N'Mostrar la cantidad de meses de antigüedad
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'APC', N'APC', N'Separar en 3 variables: Al día, es igual a valor 1 en mes acual; Maximo atraso en los ultimos 6 meses; la frecuencia en el maximo atraso.
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'ATRASOS', N'Atrasos', N'Se transforma a texto y se presenta el valor maximo de atraso y la frecuencia en los ultimos 6 meses', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'AUTO', N'Autos', N'Valor del automovil', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'CCNTA', N'ClasificacionCuenta', N'Devuelve un Caracter que clasifica la cuenta', NULL, NULL, N'SRC1', N'DDR1', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'CKDVLTO', N'CKDevuelto', N'Una transaccion en los últimos 60 días debe mostrar Sí, de lo contrario mostrar No
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'CRSSSLLNG', N'CrossSelling', N'Mostrar el saldo de pasivos, el saldo de hipoteca, el saldo de auto, el saldo de prestamo personal, y el saldo comercial
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'ESTDCNTA', N'EstatusCuenta', N'Estado de la Cuenta', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'FACTRCN', N'Facturacion', N'Mostrar el monto promedio de los ultimos 6 meses
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'FLGRECALL', N'FlagRECTodo', N'Letra N mostrar Si, de lo contrario mostrar No', NULL, NULL, N'SRC1', N'DDR1', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'FRCNCY', N'Frecuencia', N'Devuelve la Frecuencia de el reclamo realizado con un monto siendo 0 si no ha realizado este reclamo', N'[$Frecuencia(@Fecha1)]', NULL, N'SRC2', N'DDR6', N'TIPO2')
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'HPTCA', N'Hipotecas', N'Hipoteca del cliente', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'HSTRRVRSN', N'Historico Reversiones', N'Mostrar para cada cargo, cuantas reversiones tiene en los últimos 12 meses
', NULL, NULL, N'SRC1', N'DDR6', N'TIPO3')
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'INTPC', N'Intereses por Cobrar', N'Se refiere al monto de los intereses por cobrar', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'LMT', N'Limite', N'Mostra el valor Limite de Credito', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'PP', N'PPersonal', N'Prestamo Personal', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'PRDCT', N'Producto', N'Mostrar codigo de emisor', NULL, NULL, N'SRC1', N'DDR2', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'PSVOS', N'Pasivos', N'Pasivos del Cliente', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'QTYCNTAS', N'QtyOtrasCuentas', N'Mostrar cantidad de cuentas activas restando la actual
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'RACV', N'RACV', N'Mostrar el monto', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'SG', N'Sobregiro', N'Valor absoluto del resultado de la formula dividido entre el limite de credito, mostrar en porcentaje
', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'SGMNTO', N'Segmento', N'Si el valor es "bck" mostrar Black, si el valor es "cls" mostrar Clasico, si el valor es "gdl" o "gld" mostrar Dorado, si el valor es "plt" mostrar Platino
', NULL, NULL, N'SRC1', N'DDR1', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'SLDVNCDO', N'SaldoVencido', N'Si el valor es mayor a cero, mostrar sí, de lo contrario mostrar No
Saldo Vencido', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'TPOCIF', N'TipoCIF', N'mayor a 0', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_Variables] ([VariableCodigo], [VariableNombre], [VariableDescripcion], [VariableFormula], [VariableValor], [OrigenId], [DatoDeRetornoId], [TipoId]) VALUES (N'TRIAD', N'Triad', N'Valor triad que se refiere a un valor numerico', NULL, NULL, N'SRC1', N'DDR6', NULL)
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'002', N'703a61a1-0f68-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'1.25*[@Anualidad]', N'001', N'002', N'70b0fec9-0f68-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'821', N'001', N'002', N'f07550d8-0f68-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'002', N'b09f6ae3-0f68-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'002', N'30fd91ed-0f68-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'002', N'd03c4ef7-0f68-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'002', N'b09f8009-1068-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'==', N'0', N'001', N'002', N'505d8d17-1068-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'002', N'f04c7a22-1068-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>=', N'5000', N'001', N'002', N'f0f5012e-1068-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>=', N'200000', N'001', N'002', N'd06e5a40-1068-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>=', N'30000', N'001', N'002', N'd087d551-1068-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'002', N'705b0860-1068-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'001', N'002', N'b07e7e68-1068-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'002', N'906915ac-1068-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'002', N'f00a60ba-1068-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'003', N'b0e5cad2-1068-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0.25*[@Anualidad]', N'001', N'003', N'd06c88e6-1068-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'440', N'001', N'003', N'10d924f8-1068-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'003', N'f0cead02-1168-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'003', N'b019010e-1168-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'003', N'9085111b-1168-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'003', N'30784824-1168-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'003', N'd057a32b-1168-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'==', N'0', N'001', N'003', N'10684845-1168-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'003', N'70c5eb4d-1168-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>=', N'3000', N'001', N'003', N'd006d559-1168-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>=', N'125000', N'001', N'003', N'b0562b6a-1168-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>=', N'25000', N'001', N'003', N'706c547a-1168-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'003', N'70a29e81-1168-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'001', N'003', N'10791b8e-1168-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'003', N'50b2b796-1168-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'005', N'903365af-1168-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0.25*[@Anualidad]', N'001', N'005', N'103595c1-1168-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'1122', N'001', N'005', N'd0314ed3-1168-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'005', N'7044f668-1268-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'005', N'70929b75-1268-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'005', N'501fe582-1268-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'005', N'70e7f48a-1268-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'005', N'70f32797-1268-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'==', N'0', N'001', N'005', N'70c49cab-1268-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'005', N'709cbab5-1268-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>=', N'3000', N'001', N'005', N'd064d2c0-1268-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'001', N'005', N'70b420ce-1268-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'001', N'005', N'305a56d8-1268-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'005', N'f0e4e6de-1268-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'001', N'005', N'b0c944eb-1268-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'005', N'904946f3-1268-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'006', N'70d222ac-1468-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Anualidad]', N'001', N'006', N'30eb95ba-1468-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'1044', N'001', N'006', N'b092f8c6-1468-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'006', N'509042d0-1468-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'006', N'd0e5a0d8-1468-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'006', N'903e51e2-1468-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'006', N'70088eec-1468-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'006', N'f03969f6-1468-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'006', N'f086f909-1568-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'006', N'd0452314-1568-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'001', N'006', N'70246922-1568-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'001', N'006', N'3004482b-1568-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'001', N'006', N'b05cf031-1568-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'006', N'309f7238-1568-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'0', N'001', N'006', N'508f6f49-1568-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'006', N'f0acdd59-1568-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'008', N'b0c8bb9f-1568-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Anualidad]', N'001', N'008', N'd0d472ad-1568-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'410', N'001', N'008', N'103068c2-1568-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'008', N'30038bca-1568-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'008', N'f00eb6d3-1568-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'008', N'1087f6dc-1568-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'008', N'30d2d5ec-1568-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'008', N'50b355f3-1568-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'008', N'30c598fa-1568-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'001', N'008', N'd030a104-1668-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'001', N'008', N'b087a00a-1668-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'001', N'008', N'b187a00a-1668-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'008', N'd03bbf17-1668-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'0', N'001', N'008', N'100f6621-1668-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'008', N'501cb629-1668-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'008', N'd0a2f55b-1668-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'007', N'30797578-1668-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Anualidad]', N'001', N'007', N'70751e84-1668-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'220', N'001', N'007', N'30a5cc8b-1668-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'007', N'70966297-1668-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'007', N'308e9ca5-1668-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'007', N'7085c6ad-1668-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'007', N'304f7fb6-1668-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'007', N'703ee0bc-1668-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'007', N'909c9bce-1668-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'007', N'90a005d9-1668-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'001', N'007', N'904f21e1-1668-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'001', N'007', N'30c1bde7-1668-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'001', N'007', N'b0cce0ed-1668-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'007', N'108d2ff7-1668-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'0', N'001', N'007', N'70161f00-1768-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'007', N'10146909-1768-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'010', N'd072fa94-1768-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Anualidad]', N'001', N'010', N'd0dc599e-1768-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'561', N'001', N'010', N'105bb2a5-1768-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'010', N'907667af-1768-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'010', N'301685bb-1768-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'010', N'f0be04c4-1768-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'010', N'900c1ecc-1768-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'010', N'910c1ecc-1768-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'010', N'd02d6ae2-1768-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'010', N'9065e1eb-1768-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'001', N'010', N'50213df6-1768-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'001', N'010', N'51213df6-1768-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'001', N'010', N'104b5701-1868-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'010', N'b0edbe0b-1868-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'0', N'001', N'010', N'708e7512-1868-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'010', N'f0289019-1868-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'011', N'b02b1f9a-1868-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0', N'001', N'011', N'f04382a2-1868-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'001', N'011', N'9073aca8-1868-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'011', N'301614b3-1868-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'011', N'9004e4c1-1868-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'011', N'90cebaf3-1868-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'011', N'10062afa-1868-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'011', N'11062afa-1868-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'011', N'b078e60c-1968-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'011', N'70344217-1968-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'011', N'f0e2582c-1968-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'012', N'f07ae517-3668-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0', N'001', N'012', N'5088b921-3668-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'001', N'012', N'5188b921-3668-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'012', N'd0b87f32-3668-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'012', N'50453d3b-3668-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'012', N'd0fafc45-3668-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'012', N'5016b24f-3668-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'012', N'70913c57-3668-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'012', N'd0a7f96e-3668-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'012', N'd085ab75-3668-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'012', N'90612b87-3668-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'013', N'1072eec9-3668-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0', N'001', N'013', N'b06425d3-3668-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'001', N'013', N'f04873d9-3668-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'013', N'f0d30be3-3668-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'013', N'7060c9eb-3668-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'013', N'30bcc3f3-3668-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'013', N'd00693fd-3668-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'013', N'709ee707-3768-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'013', N'50db6116-3768-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'013', N'10be8a1d-3768-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'013', N'd0fa802a-3768-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'015', N'50eaf446-3768-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0', N'001', N'015', N'90b5d24e-3768-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'001', N'015', N'f099a456-3768-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'015', N'b0ecc063-3768-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'001', N'015', N'f090d16e-3768-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'001', N'015', N'd044e878-3768-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'015', N'90559285-3768-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'015', N'f027a897-3768-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'015', N'b071e6a9-3768-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'001', N'015', N'50f65eb2-3768-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'015', N'107811be-3768-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'001', N'd04fe208-3968-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'260', N'003', N'001', N'd0a31b12-3968-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'171', N'003', N'001', N'd00d7b1b-3968-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'001', N'f0ca7723-3968-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'001', N'f0a6ff37-3968-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'001', N'90206540-3968-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'001', N'502fda47-3968-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'==', N'0', N'003', N'001', N'1043ce52-3968-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'001', N'50260760-3968-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'001', N'f0c3ef66-3968-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'001', N'30979670-3968-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'002', N'50a34d7e-3968-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'260', N'003', N'002', N'100a5b86-3968-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'171', N'003', N'002', N'd07b7b8e-3968-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'002', N'3052f097-3968-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'002', N'108d35a1-3968-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'002', N'305545a9-3968-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'002', N'10a67b88-3e68-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'==', N'0', N'003', N'002', N'10524d92-3e68-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'002', N'5040999f-3e68-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'002', N'1023c2a6-3e68-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'003', N'002', N'f065d0b1-3e68-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'003', N'002', N'90006fba-3e68-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'003', N'002', N'900a6dc1-3e68-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'003', N'002', N'910a6dc1-3e68-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'003', N'002', N'f0d703d0-3e68-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'002', N'70d27fd9-3e68-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'003', N'10a16a43-3f68-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'505', N'003', N'003', N'903dba4f-3f68-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'440', N'003', N'003', N'9028b45b-3f68-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'003', N'b08c036a-3f68-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'003', N'704ba972-3f68-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'003', N'3032e3d6-4568-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'003', N'70a528de-4568-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'==', N'0', N'003', N'003', N'10dc06ed-4568-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'003', N'70f3d8fd-4568-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'003', N'309fa204-4668-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'003', N'b0af440e-4668-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'004', N'7030e220-4668-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'505', N'003', N'004', N'5057362f-4668-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'440', N'003', N'004', N'50aeb936-4668-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'004', N'b019ba3d-4668-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'004', N'30853e46-4668-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'004', N'3005c44f-4668-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'004', N'f0b08d56-4668-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'==', N'0', N'003', N'004', N'b064205f-4668-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'004', N'd0c0a66b-4668-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'004', N'102b0e78-4668-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'003', N'004', N'b0515a83-4668-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'003', N'004', N'b1515a83-4668-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'003', N'004', N'70961992-4668-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'003', N'004', N'10bb3098-4668-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'003', N'004', N'b0c6d79f-4668-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'004', N'b0eb7aaa-4668-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'005', N'301c41bb-4668-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'693', N'003', N'005', N'3086a0c4-4668-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'821', N'003', N'005', N'd0c212d0-4668-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'005', N'd0f2c8da-4668-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'005', N'301d9826-4768-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'005', N'd01ae22f-4768-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'005', N'd034723a-4768-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'==', N'0', N'003', N'005', N'70a5f947-4768-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'005', N'107c7654-4768-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'005', N'109c9a5b-4768-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'005', N'f09c3666-4768-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'006', N'b0440421-4868-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'693', N'003', N'006', N'd077882b-4868-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'821', N'003', N'006', N'90b47e38-4868-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'006', N'50ef3f40-4868-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'006', N'309dc24d-4868-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'006', N'd0e79157-4868-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'006', N'3053925e-4868-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<', N'0', N'003', N'006', N'70a13f6e-4868-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'006', N'd0ec2681-4868-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'006', N'f093fd88-4868-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'003', N'006', N'90152c93-4868-e811-803e-001c4222cceb', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'003', N'006', N'f0f3699e-4868-e811-803e-001c4222cceb', N'Hipotecas')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'003', N'006', N'7067b7a8-4868-e811-803e-001c4222cceb', N'Autos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'003', N'006', N'70f77ee6-4968-e811-803e-001c4222cceb', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'003', N'006', N'70ae63f0-4968-e811-803e-001c4222cceb', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'006', N'70b2cdfa-4968-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'003', N'007', N'3080f00d-4a68-e811-803e-001c4222cceb', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'612', N'003', N'007', N'b061fc18-4a68-e811-803e-001c4222cceb', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'2088', N'003', N'007', N'70124523-4a68-e811-803e-001c4222cceb', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'003', N'007', N'10d92f2c-4a68-e811-803e-001c4222cceb', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'003', N'007', N'505c0737-4a68-e811-803e-001c4222cceb', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'003', N'007', N'50203446-4a68-e811-803e-001c4222cceb', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'003', N'007', N'50b6df4f-4a68-e811-803e-001c4222cceb', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<', N'0', N'003', N'007', N'f0e73e5b-4a68-e811-803e-001c4222cceb', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'003', N'007', N'102e9f67-4a68-e811-803e-001c4222cceb', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'003', N'007', N'30f36471-4a68-e811-803e-001c4222cceb', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'6', N'003', N'007', N'30a16b80-4a68-e811-803e-001c4222cceb', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'001', N'f2b76279-044b-e811-9e39-9cb6d0034a0e', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0.25*[@Anualidad]', N'001', N'001', N'b28e6ab6-044b-e811-9e39-9cb6d0034a0e', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'2088', N'001', N'001', N'dc39ede1-044b-e811-9e39-9cb6d0034a0e', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'001', N'd30891fd-044b-e811-9e39-9cb6d0034a0e', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1, 2, 3, 4, 5}', N'001', N'001', N'73da9f40-054b-e811-9e39-9cb6d0034a0e', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1, 2, 3}', N'001', N'001', N'60641057-054b-e811-9e39-9cb6d0034a0e', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'001', N'27277260-054b-e811-9e39-9cb6d0034a0e', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'001', N'e07a7f6f-054b-e811-9e39-9cb6d0034a0e', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'==', N'0', N'001', N'001', N'37cdc47e-054b-e811-9e39-9cb6d0034a0e', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'NULL', N'001', N'001', N'03c93a8a-054b-e811-9e39-9cb6d0034a0e', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>=', N'10000', N'001', N'001', N'5f0abfbb-054b-e811-9e39-9cb6d0034a0e', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>=', N'250000', N'001', N'001', N'18c1f5f9-054b-e811-9e39-9cb6d0034a0e', N'Hipoteca')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>=', N'40000', N'001', N'001', N'b080e76f-064b-e811-9e39-9cb6d0034a0e', N'Auto')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'001', N'1e89567d-064b-e811-9e39-9cb6d0034a0e', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'001', N'001', N'620b5188-064b-e811-9e39-9cb6d0034a0e', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'001', N'9def1592-064b-e811-9e39-9cb6d0034a0e', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'002', N'001', N'2f8d5bc3-3a60-e811-9e65-9cb6d0034a0e', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Monto]', N'002', N'001', N'acdfbbe7-3a60-e811-9e65-9cb6d0034a0e', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'002', N'001', N'52ddd5f8-3a60-e811-9e65-9cb6d0034a0e', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'002', N'001', N'6227d70a-3b60-e811-9e65-9cb6d0034a0e', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'002', N'001', N'8186f91f-3b60-e811-9e65-9cb6d0034a0e', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'002', N'001', N'103b5a2e-3b60-e811-9e65-9cb6d0034a0e', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'002', N'001', N'f26faf3a-3b60-e811-9e65-9cb6d0034a0e', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'2', N'002', N'001', N'a254c852-3b60-e811-9e65-9cb6d0034a0e', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'002', N'001', N'3af4e06c-3b60-e811-9e65-9cb6d0034a0e', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'002', N'001', N'92e1a89a-3b60-e811-9e65-9cb6d0034a0e', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'002', N'001', N'20c1fba9-3b60-e811-9e65-9cb6d0034a0e', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'002', N'001', N'ce2595b4-3b60-e811-9e65-9cb6d0034a0e', N'Hipoteca')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'002', N'001', N'06129dbc-3b60-e811-9e65-9cb6d0034a0e', N'Auto')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'002', N'001', N'74e452c4-3b60-e811-9e65-9cb6d0034a0e', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'002', N'001', N'fb3925d1-3b60-e811-9e65-9cb6d0034a0e', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'002', N'001', N'25c97add-3b60-e811-9e65-9cb6d0034a0e', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'>=', N'30', N'002', N'002', N'1171430b-3c60-e811-9e65-9cb6d0034a0e', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'180', N'002', N'002', N'85c7a416-3c60-e811-9e65-9cb6d0034a0e', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Monto]', N'002', N'002', N'715c2723-3c60-e811-9e65-9cb6d0034a0e', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'002', N'002', N'348ad22e-3c60-e811-9e65-9cb6d0034a0e', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'002', N'002', N'839a850f-5660-e811-9e66-9cb6d0034a0e', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'002', N'002', N'5f1b061b-5660-e811-9e66-9cb6d0034a0e', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'002', N'002', N'8f462040-5660-e811-9e66-9cb6d0034a0e', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'002', N'002', N'227e8668-5660-e811-9e66-9cb6d0034a0e', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'2', N'002', N'002', N'8324d771-5660-e811-9e66-9cb6d0034a0e', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[Limite]', N'002', N'002', N'f834a891-5660-e811-9e66-9cb6d0034a0e', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'002', N'002', N'e29f6151-5760-e811-9e66-9cb6d0034a0e', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'002', N'002', N'3f63fb61-5760-e811-9e66-9cb6d0034a0e', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'002', N'002', N'd8d13c7b-5760-e811-9e66-9cb6d0034a0e', N'Hipoteca')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'002', N'002', N'1a7c928f-5760-e811-9e66-9cb6d0034a0e', N'Auto')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'002', N'002', N'9c40cd9a-5760-e811-9e66-9cb6d0034a0e', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'002', N'002', N'a6bc0fa8-5760-e811-9e66-9cb6d0034a0e', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'002', N'002', N'a97b1dbf-5760-e811-9e66-9cb6d0034a0e', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'>=', N'30', N'002', N'003', N'a70b0936-5a60-e811-9e66-9cb6d0034a0e', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'180', N'002', N'003', N'b7424440-5a60-e811-9e66-9cb6d0034a0e', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Monto]', N'002', N'003', N'05a0d00e-5c60-e811-9e66-9cb6d0034a0e', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'002', N'003', N'5040561c-5c60-e811-9e66-9cb6d0034a0e', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'002', N'003', N'd3766826-5c60-e811-9e66-9cb6d0034a0e', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1,2,3,4,5}', N'002', N'003', N'bf082931-5c60-e811-9e66-9cb6d0034a0e', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1,2,3}', N'002', N'003', N'ea6f8c3a-5c60-e811-9e66-9cb6d0034a0e', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'002', N'003', N'8fecdf44-5c60-e811-9e66-9cb6d0034a0e', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'2', N'002', N'003', N'ac03e14e-5c60-e811-9e66-9cb6d0034a0e', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[Limite]', N'002', N'003', N'1d2b6e5b-5c60-e811-9e66-9cb6d0034a0e', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'Vacio', N'002', N'003', N'488a4b65-5c60-e811-9e66-9cb6d0034a0e', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'002', N'003', N'c0e39f6d-5c60-e811-9e66-9cb6d0034a0e', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'002', N'003', N'1794e275-5c60-e811-9e66-9cb6d0034a0e', N'Hipoteca')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'002', N'003', N'd1a5b17d-5c60-e811-9e66-9cb6d0034a0e', N'Auto')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'002', N'003', N'10629751-5d60-e811-9e66-9cb6d0034a0e', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'002', N'003', N'000ea05b-5d60-e811-9e66-9cb6d0034a0e', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'002', N'003', N'9d7e4163-5d60-e811-9e66-9cb6d0034a0e', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'004', N'ea849499-ab57-e811-9e56-9eb6d0034a0d', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0.25 * [@Anualidad]', N'001', N'004', N'adf294ae-ab57-e811-9e56-9eb6d0034a0d', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'171', N'001', N'004', N'2eaaf9ba-ab57-e811-9e56-9eb6d0034a0d', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'004', N'5e21dbc7-ab57-e811-9e56-9eb6d0034a0d', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1, 2, 3, 4, 5}', N'001', N'004', N'fa4ca0e4-ab57-e811-9e56-9eb6d0034a0d', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1, 2, 3}', N'001', N'004', N'88d729f0-ab57-e811-9e56-9eb6d0034a0d', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'004', N'f7e78ef9-ab57-e811-9e56-9eb6d0034a0d', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'004', N'e092e603-ac57-e811-9e56-9eb6d0034a0d', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'==', N'0', N'001', N'004', N'0b2ee716-ac57-e811-9e56-9eb6d0034a0d', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'NULL', N'001', N'004', N'f1f47b23-ac57-e811-9e56-9eb6d0034a0d', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>=', N'250', N'001', N'004', N'6f740c2e-ac57-e811-9e56-9eb6d0034a0d', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>=', N'65000', N'001', N'004', N'e2405b36-ac57-e811-9e56-9eb6d0034a0d', N'Hipoteca')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>=', N'5000', N'001', N'004', N'a955d741-ac57-e811-9e56-9eb6d0034a0d', N'Auto')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'004', N'7e4b314b-ac57-e811-9e56-9eb6d0034a0d', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'1', N'001', N'004', N'2effa85a-ac57-e811-9e56-9eb6d0034a0d', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'004', N'eab43765-ac57-e811-9e56-9eb6d0034a0d', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'009', N'8f21b678-ac57-e811-9e56-9eb6d0034a0d', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>=', N'[@Anualidad]', N'001', N'009', N'03a9f385-ac57-e811-9e56-9eb6d0034a0d', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>=', N'85', N'001', N'009', N'bfea6290-ac57-e811-9e56-9eb6d0034a0d', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'009', N'18c4899c-ac57-e811-9e56-9eb6d0034a0d', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1, 2, 3, 4, 5}', N'001', N'009', N'86098baa-ac57-e811-9e56-9eb6d0034a0d', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1, 2, 3}', N'001', N'009', N'e552d849-ad57-e811-9e56-9eb6d0034a0d', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'009', N'92e7d553-ad57-e811-9e56-9eb6d0034a0d', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'009', N'2ebfd559-ad57-e811-9e56-9eb6d0034a0d', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25*[@Limite]', N'001', N'009', N'528b178d-ad57-e811-9e56-9eb6d0034a0d', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'NULL', N'001', N'009', N'7b7dbf94-ad57-e811-9e56-9eb6d0034a0d', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PSVOS', N'>', N'0', N'001', N'009', N'39ae5d9e-ad57-e811-9e56-9eb6d0034a0d', N'Pasivos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'HPTCA', N'>', N'0', N'001', N'009', N'da11d6a6-ad57-e811-9e56-9eb6d0034a0d', N'Hipoteca')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'AUTO', N'>', N'0', N'001', N'009', N'09705ab3-ad57-e811-9e56-9eb6d0034a0d', N'Auto')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'PP', N'>', N'0', N'001', N'009', N'6fc8ebbc-ad57-e811-9e56-9eb6d0034a0d', N'PPersonal')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TPOCIF', N'>', N'0', N'001', N'009', N'606fb1d4-ad57-e811-9e56-9eb6d0034a0d', N'TipoCIF')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'009', N'bf955309-ae57-e811-9e56-9eb6d0034a0d', N'Antiguedad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FRCNCY', N'<=', N'365', N'001', N'014', N'6eda5046-ae57-e811-9e56-9eb6d0034a0d', N'Frecuencia')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'RACV', N'>', N'0', N'001', N'014', N'48d11b4f-ae57-e811-9e56-9eb6d0034a0d', N'RACV')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FACTRCN', N'>', N'0', N'001', N'014', N'07f53e57-ae57-e811-9e56-9eb6d0034a0d', N'Facturacion')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'TRIAD', N'>=', N'570', N'001', N'014', N'dc3c966f-ae57-e811-9e56-9eb6d0034a0d', N'Triad')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'CCNTA', N'==', N'{1, 2, 3, 4, 5}', N'001', N'014', N'd4b65f7c-ae57-e811-9e56-9eb6d0034a0d', N'ClasificacionCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ESTDCNTA', N'==', N'{1, 2, 3}', N'001', N'014', N'46f98e85-ae57-e811-9e56-9eb6d0034a0d', N'EstatusCuenta')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SLDVNCDO', N'==', N'0', N'001', N'014', N'e3a8138f-ae57-e811-9e56-9eb6d0034a0d', N'SaldoVencido')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ATRASOS', N'<=', N'1', N'001', N'014', N'e4a8138f-ae57-e811-9e56-9eb6d0034a0d', N'Atrasos')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'SG', N'<=', N'0.25 * [@Limite]', N'001', N'014', N'082471b9-ae57-e811-9e56-9eb6d0034a0d', N'Sobregiro')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'FLGRECALL', N'==', N'NULL', N'001', N'014', N'dc44bac5-ae57-e811-9e56-9eb6d0034a0d', N'FlagRECTodo')
GO
INSERT [dbo].[SGRC_VariablesDeItems] ([VariableCodigo], [CondicionLogica], [ValorAEvaluar], [ReclamoId], [ItemDeReclamoId], [VariableDeItemId], [VariableNombre]) VALUES (N'ANTGD', N'>=', N'3', N'001', N'014', N'02126ace-ae57-e811-9e56-9eb6d0034a0d', N'Antiguedad')
GO
INSERT [dbo].[SECA_Modulo] ([Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'Sistema de Gestiones de Retencion', N'A')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as01', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as02', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as03', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as04', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as05', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as06', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as07', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as08', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as09', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as10', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as11', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as12', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as13', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as14', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as15', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as16', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as17', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'as18', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'ADM')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'CYR')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'DPC')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'EDA')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'PDC')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'jbonilla', N'SGRC', N'SUP')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'lcervantes', N'SGRC', N'ADM')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'lcervantes', N'SGRC', N'CYR')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'lcervantes', N'SGRC', N'EDA')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'lcervantes', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'lcervantes', N'SGRC', N'PDC')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'rgarcia', N'SGRC', N'ADM')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'rgarcia', N'SGRC', N'CYR')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'rgarcia', N'SGRC', N'DPC')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'rgarcia', N'SGRC', N'EDA')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'rgarcia', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'rgarcia', N'SGRC', N'SUP')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'riromerol', N'SGRC', N'ADM')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'riromerol', N'SGRC', N'CYR')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'riromerol', N'SGRC', N'EDA')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'riromerol', N'SGRC', N'EDS')
GO
INSERT [dbo].[SECA_UsuarioRol] ([CodigoUsuario], [CodigoModulo], [CodigoRol]) VALUES (N'riromerol', N'SGRC', N'PDC')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADM', N'Administrador', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYR', N'Consultas y Reportes', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'DPC', N'Display Clientes', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'EDA', N'Ejecutivo de Atencion', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'EDS', N'Ejecutivo de Servicios de Retencion', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'PDC', N'Programacion de Citas', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'PDCR', N'Programacion de Citas Restrictivo', N'A')
GO
INSERT [dbo].[SECA_Rol] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'SUP', N'Supervisor', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADCC', N'Atencion de Citas Cliente', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADCC010', N'Dash de Bienvenida', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADCC0101', N'DashBoard Bienvenida - Seleccion de Agencia', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADCC0102', N'DashBoard Bienvenida - Tomar acciones en Grids', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADCC020', N'Autoservicio Bienvenida', N'I')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'ADCC030', N'Atencion de Citas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF', N'Configuracion', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF010', N'Catalogo General', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF020', N'Prioridades', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF030', N'Feriados', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF040', N'Tramites', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF050', N'Razones de Cancelacion', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF060', N'Sucursales', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF070', N'Emisores', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF080', N'Variables', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF090', N'Funciones', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CONF100', N'Configuraciones Motor', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS', N'Consultas y Reportes', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS010', N'Dashboard por estado de citas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS020', N'Dashboard de atenciones', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS030', N'Dashboard de atenciones por rangos', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS040', N'Dashboard de efectividad', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS050', N'Dashboard tiempo real de atencion', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS060', N'Dashboard tiempos de atencion', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS070', N'Dashboard razones por incidencia', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS080', N'Reporte origen de citas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS090', N'Reporte diario de citas y razones de cancelacion', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS100', N'Reporte atenciones realizadas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS110', N'Dashboard de Comportamiento de Incidencias', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS120', N'Dashboard Atencion por tiempo espera', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS130', N'Dashboard Manta de Datos', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'CYRS140', N'Dashboard Incidencia de Motor', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'DPCF', N'Pantalla Display de Clientes', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'DPCF01', N'Pantalla Display de Clientes', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'MTR', N'Motor de Retenciones', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'MTR020', N'Evaluacion de Anualidades', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'MTR030', N'Evaluacion de Reversiones', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'MTR040', N'Evaluacion de Tasas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'MTR050', N'Evaluacion de Combos', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'PDCC', N'Programacion de Citas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'PDCC010', N'Programar Citas', N'A')
GO
INSERT [dbo].[SECA_Privilegio] ([CodigoModulo], [Codigo], [Nombre], [Estado]) VALUES (N'SGRC', N'PDCC020', N'Programar Citas con Restricciones', N'A')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF010')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF020')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF030')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF040')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF050')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF060')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF070')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF080')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF090')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'CONF100')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'MTR')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'MTR020')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'MTR030')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'MTR040')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'ADM', N'MTR050')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS010')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS020')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS030')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS040')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS050')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS060')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS070')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS080')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS090')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS100')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS110')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS120')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS130')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'CYR', N'CYRS140')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'DPC', N'DPCF')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'DPC', N'DPCF01')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'EDA', N'ADCC')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'EDA', N'ADCC010')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'EDA', N'ADCC0102')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'EDS', N'ADCC')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'EDS', N'ADCC030')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'PDC', N'PDCC')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'PDC', N'PDCC010')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'PDC', N'PDCC020')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'PDCR', N'PDCC')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'PDCR', N'PDCC020')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'SUP', N'ADCC')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'SUP', N'ADCC010')
GO
INSERT [dbo].[SECA_RolPrivilegio] ([CodigoModulo], [CodigoRol], [CodigoPrivilegio]) VALUES (N'SGRC', N'SUP', N'ADCC0101')
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as01', N'prog4-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as02', N'walk4-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as03', N'prog5-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as04', N'walk5-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as05', N'prog36-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as06', N'prog36-2', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as07', N'walk36-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as08', N'walk-36-2', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as09', N'walk44-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as10', N'walk44-2', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as11', N'walk44-3', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as12', N'walk44-4', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as13', N'prg44-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as14', N'prg44-2', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as15', N'prog45-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as16', N'prog45-2', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as17', N'walk45-1', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'as18', N'walk45-2', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'jbonilla', N'Jairo Bonilla', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'lcervantes', N'Lester Cervantes', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'rgarcia', N'Roberto Garcia', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
INSERT [dbo].[SECA_Usuario] ([Codigo], [Nombre], [CodigoAS400A], [CodigoAS400B], [CodigoSIEBEL], [Email], [Estado], [NivelAprobacion], [CodigoEmpleado]) VALUES (N'riromerol', N'Ricardo Romero', NULL, NULL, NULL, N'rromero@sytcorp.com', N'A', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SGRC_Tramite] ON 
GO
INSERT [dbo].[SGRC_Tramite] ([TramiteId], [TramiteDescripcion], [TramiteAbreviatura], [TramiteDuracion], [TramiteAlertaPrevia], [TramiteToleranciaAlCliente], [TramiteToleranciaDelCliente], [TramiteToleranciaFinalizacion], [TramiteTiempoMuerto]) VALUES (2, N'Reversion-Desc', N'Reversion', 30, 5, 10, 5, 10, 15)
GO
INSERT [dbo].[SGRC_Tramite] ([TramiteId], [TramiteDescripcion], [TramiteAbreviatura], [TramiteDuracion], [TramiteAlertaPrevia], [TramiteToleranciaAlCliente], [TramiteToleranciaDelCliente], [TramiteToleranciaFinalizacion], [TramiteTiempoMuerto]) VALUES (3, N'Tasa de Interes-Desc', N'Tasa de Interes', 30, 5, 10, 5, 10, 15)
GO
INSERT [dbo].[SGRC_Tramite] ([TramiteId], [TramiteDescripcion], [TramiteAbreviatura], [TramiteDuracion], [TramiteAlertaPrevia], [TramiteToleranciaAlCliente], [TramiteToleranciaDelCliente], [TramiteToleranciaFinalizacion], [TramiteTiempoMuerto]) VALUES (4, N'Combos-Desc', N'Combos', 30, 5, 10, 5, 10, 15)
GO
INSERT [dbo].[SGRC_Tramite] ([TramiteId], [TramiteDescripcion], [TramiteAbreviatura], [TramiteDuracion], [TramiteAlertaPrevia], [TramiteToleranciaAlCliente], [TramiteToleranciaDelCliente], [TramiteToleranciaFinalizacion], [TramiteTiempoMuerto]) VALUES (14, N'Trámite de prueba-Desc', N'PRB', 30, 5, 10, 5, 10, 15)
GO
INSERT [dbo].[SGRC_Tramite] ([TramiteId], [TramiteDescripcion], [TramiteAbreviatura], [TramiteDuracion], [TramiteAlertaPrevia], [TramiteToleranciaAlCliente], [TramiteToleranciaDelCliente], [TramiteToleranciaFinalizacion], [TramiteTiempoMuerto]) VALUES (0, N'Tamite Auto Servicio', N'Tamite Auto Servicio', 30, 5, 10, 5, 10, 15)
GO
INSERT [dbo].[SGRC_Tramite] ([TramiteId], [TramiteDescripcion], [TramiteAbreviatura], [TramiteDuracion], [TramiteAlertaPrevia], [TramiteToleranciaAlCliente], [TramiteToleranciaDelCliente], [TramiteToleranciaFinalizacion], [TramiteTiempoMuerto]) VALUES (15, N'Anualidad-Desc', N'Anualidad', 30, 5, 10, 5, 10, 15)
GO
SET IDENTITY_INSERT [dbo].[SGRC_Tramite] OFF
GO
