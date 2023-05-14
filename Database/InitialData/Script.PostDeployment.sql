


SET IDENTITY_INSERT [Player] ON;  

INSERT [Player] (PlayerId, Pseudo, Email, Password_Hash)
 VALUES (1, 'Della','della.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (2, 'Bella','bella.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (3, 'Mina','mina.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (4, 'Toni','toni.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (5, 'Robin','robin.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (6, 'Tom','tom.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (7, 'Marc','marc.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE'),
		  (8, 'Seb','seb.duck@gmail.com', '$argon2id$v=19$m=65536,t=3,p=1$w2bXdVSDo21XVLOxVm/wPA$G9BB6aRxjVIZIpaxitDYOpbQiRT1dGGEdRapZmOEPoE')

SET IDENTITY_INSERT [Player] OFF;  


