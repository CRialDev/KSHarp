import xbmc
import xbmcaddon
import xbmcgui
import xbmcplugin
import xbmcvfs
import subprocess
import os
import signal
import threading
import types
import json

NewLine = '\n'
libraryType = {'video': '0', 'music': '1'}

class Listener:
	def __init__(self):
		args = []
		args.append('mono')
		args.append(xbmcaddon.Addon().getAddonInfo('path')+'/KSharp/addon.exe')
		self.proc = subprocess.Popen(args, stdin=subprocess.PIPE, stderr=subprocess.PIPE, stdout=subprocess.PIPE)
	
	def Execute(self):
		line = self.proc.stdout.readline()
		if line !='':
			xbmc.log(msg='Python : Recu : '+line, level=xbmc.LOGNOTICE)
			exec(line)

	def StartReader(self):
		self.addonStarted = True
		while self.addonStarted:
			self.Execute()
			
	def StartEventReader(self):
		self.EventStarted = True
		while self.EventStarted:
			self.Execute()
		
	def Write(self, value):
		self.proc.stdin.write(value+'\n')
		xbmc.log(msg='Python : Envoyer: '+value, level=xbmc.LOGNOTICE)
	
li = Listener()

class Monitor(xbmc.Monitor):

	def onSettingsChanged(self):
		li.Write('3:'+self.mtname+':0')
		li.StartEventReader()
		
	def onCleanFinished(self, library):
		li.Write('3:'+self.mtname+':4:'+libraryType[library])
		li.StartEventReader()
		
	def onCleanStarted(self, library):
		li.Write('3:'+self.mtname+':3:'+libraryType[library])
		li.StartEventReader()
		
	def onScanFinished(self, library):
		li.Write('3:'+self.mtname+':6:'+libraryType[library])
		li.StartEventReader()
		
	def onScanStarted(self, library):
		li.Write('3:'+self.mtname+':5:'+libraryType[library])
		li.StartEventReader()
		
	def onNotification(self,sender, method, data):
		li.Write('3:'+self.mtname+':7:'+sender+':'+method+':'+data)
		li.StartEventReader()
		
	def onScreensaverActivated(self):
		li.Write('3:'+self.mtname+':1')
		li.StartEventReader()
		
	def onScreensaverDeactivated(self):
		li.Write('3:'+self.mtname+':2')
		li.StartEventReader()
		
	def onDPMSActivated(self):
		li.Write('3:'+self.mtname+':8')
		li.StartEventReader()
		
	def onDPMSDeactivated(self):
		li.Write('3:'+self.mtname+':9')
		li.StartEventReader()

class Window(xbmcgui.Window):
	
	def doModal(self):
		super(Window,self).doModal()
		return "Closed"
		
	def onAction(self, action):
		if action.getId() != 107:
			li.Write('1:'+self.winname+':'+str(action.getId()))
			li.StartEventReader()
		
	def onControl(self, control):
		li.Write('2:'+str(control.getId()))
		li.StartEventReader()
		
class WindowDialog(xbmcgui.WindowDialog):

	def doModal(self):
		super(WindowDialog,self).doModal()
		return "Closed"

	def onAction(self, action):
		if action.getId() != 107:
			li.Write('1:'+self.winname+':'+str(action.getId()))
			li.StartEventReader()
		
	def onControl(self, control):
		li.Write('2:'+str(control.getId()))
		li.StartEventReader()
		
class WindowXMLDialog(xbmcgui.WindowXMLDialog):

	def onInit(self):
		li.Write('4:'+self.winname)
		li.StartEventReader()

	def doModal(self):
		super(WindowXMLDialog,self).doModal()
		return "Closed"
		
	def onAction(self, action):
		if action.getId() != 107:
			li.Write('1:'+self.winname+':'+str(action.getId()))
			li.StartEventReader()
		
	def onControl(self, control):
		li.Write('2:'+str(control.getId()))
		li.StartEventReader()

	def onFocus(self, controlId):
		li.Write('5:'+str(controlId))
		li.StartEventReader()
		
 	def onDoubleClick(self, controlId):
		li.Write('6:'+str(controlId))
		li.StartEventReader()
       
	def onClick(self, controlId):
		li.Write('2:'+str(controlId))
		li.StartEventReader()
		
class WindowXML(xbmcgui.WindowXML):

	def onInit(self):
		li.Write('4:'+self.winname)
		li.StartEventReader()

	def doModal(self):
		super(WindowXMLDialog,self).doModal()
		return "Closed"
		
	def onAction(self, action):
		if action.getId() != 107:
			li.Write('1:'+self.winname+':'+str(action.getId()))
			li.StartEventReader()
		
	def onControl(self, control):
		li.Write('2:'+str(control.getId()))
		li.StartEventReader()

	def onFocus(self, controlId):
		li.Write('5:'+str(controlId))
		li.StartEventReader()
		
 	def onDoubleClick(self, controlId):
		li.Write('6:'+str(controlId))
		li.StartEventReader()
       
	def onClick(self, controlId):
		li.Write('2:'+str(controlId))
		li.StartEventReader()
    
li.StartReader()
xbmc.log('Quit Addon', level=xbmc.LOGNOTICE)