#!/usr/bin/python
# -*- coding: iso-8859-1 -*-
import serial
comport = serial.Serial('COM4', 9600) 
print ('Serial Iniciada...\n')

import mysql.connector
cnx = mysql.connector.connect(user='root', password='root', host='127.0.0.1', database='jupiter', auth_plugin='mysql_native_password')
cursor = cnx.cursor()
add_sinais = ("INSERT INTO temperatura (temperatura_atual, id_incubadora) VALUES (%s, 1)")

while (True):
  serialValue = comport.readline()
  data_sinais = serialValue.split()
  cursor.execute(add_sinais, data_sinais)
  cnx.commit()

cursor.close()
cnx.close()
comport.close()
