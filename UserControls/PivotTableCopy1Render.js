function PivotTableCopy1($) {
	 this.setSDTProjects = function(value) {
			this.SDTProjects = value;
		}

		this.getSDTProjects = function() {
			return this.SDTProjects;
		} 
	  
	 this.setSDTEmployeeProjectHoursCollection = function(value) {
			this.SDTEmployeeProjectHoursCollection = value;
		}

		this.getSDTEmployeeProjectHoursCollection = function() {
			return this.SDTEmployeeProjectHoursCollection;
		} 
	  
	 this.setProjectHours = function(value) {
			this.ProjectHours = value;
		}

		this.getProjectHours = function() {
			return this.ProjectHours;
		} 
	  
	  
	  

	var template = '<div id=\'print\' ><table class=\"gx-tab-spacing-fix-2 GridWithPaginationBar GridWithBorderColor WorkWith table-responsive\" style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>	<thead  style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>		<tr>			<th style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>Projects:</th>			{{#SDTProjects}}			<th style=\'border: 1px solid #dddddd; border-collapse: collapse;\' scope=\"col\" ><a href=\'\' {{ProjectClicked}}>{{ProjectName}}</a></th>			{{/SDTProjects}}			<th style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>Total Work Hours</th>			{{#ShowLeaveTotal}}<th class=\'leave\'>Total Leave Hours</th>{{/ShowLeaveTotal}}			<!--<th style=\'border: 1px solid #dddddd; border-collapse: collapse;\'></th>-->		</tr>	</thead>	<tbody>		{{#SDTEmployeeProjectHoursCollection}}		<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd\">				<td style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'><a href=\'\'  data-event=\"Click\" >{{EmployeeName}}</a></td>						{{#SDTProjects}}			<td id=\'{{EmployeeId}}-{{Id}}\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\'></td>			{{/SDTProjects}}						<td style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'>				<span class=\"tag\" style=\'padding: 0.5rem; {{#IsWorkTimeOptimal}} background:#00a95c; color:white; border-radius:5px;{{/IsWorkTimeOptimal}}\'>{{TotalFormattedTime}}</span>			</td>			<!--<td style=\'border: 1px solid #dddddd; border-collapse: collapse;font-weight: bold;background:#f5f5f5;\'>{{TotalTime}} {{ExpectedWorkTime}} {{IsWorkTimeOptimal}}</td>-->			{{#ShowLeaveTotal}}<td class=\'leave\' style=\'border: 1px solid #dddddd;font-weight: bold; border-collapse: collapse;background:#f5f5f5;\'>{{TotalFormattedLeave}}</td>{{/ShowLeaveTotal}}			<!--<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'><a href=\'\'  data-event=\"Click\" >Details</a></td>-->		</tr>		{{/SDTEmployeeProjectHoursCollection}}	</tbody>		<tfoot>		<tr class=\"GridWithPaginationBar GridNoBorder WorkWithOdd\">			<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'>Total</td>			{{#SDTProjects}}			<td class=\'project-total\' id=\'{{Id}}\' style=\'border: 1px solid #dddddd; border-collapse: collapse;\' scope=\"col\">0</td>			{{/SDTProjects}}			<td id=\'totalWorkHours\' style=\'border: 1px solid #dddddd; border-collapse: collapse;bold;background:#f5f5f5;\'>{{TotalFormattedWorkTime}}</td>			{{#ShowLeaveTotal}}<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'></td>{{/ShowLeaveTotal}}			<!--<td style=\'border: 1px solid #dddddd; border-collapse: collapse;\'></td>-->		</tr>	<tfoot>		</table></div>';
	var partials = {  }; 
	Mustache.parse(template);
	var _iOnClick = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnClick = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Click']")
				.on('click', this.onClickHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts
			this.Start(); 
	}

	this.Scripts = [];

		this.Start = function() {

					function formatMinutesToHHMM(minutes) {
						var hours = Math.floor(minutes / 60);
						var remainingMinutes = minutes % 60;
						// Adding leading zeros if necessary
						var formattedHours = hours < 10 ? '0' + hours : hours;
						var formattedMinutes = remainingMinutes < 10 ? '0' + remainingMinutes : remainingMinutes;	
						return formattedHours + ':' + formattedMinutes;
					}
				
				
					for (let i = 0; i < this.SDTEmployeeProjectHoursCollection.length; i++) {
						var employee = this.SDTEmployeeProjectHoursCollection[i]
						var employeeId = employee.EmployeeId
						var projects = employee.ProjectHours
						console.log(employee.ExpectedWorkTime)
						console.log(employee.TotalTime)
						
						
						if (projects) {
							for (let j=0; j < projects.length; j++) {
								var project = projects[j]
								var cell = document.getElementById(`${employeeId}-${project.ProjectId}`)
								cell.innerHTML = project.ProjectFormattedTime
								var totalCell = document.getElementById(`${project.ProjectId}`)
								totalCell.innerHTML = parseInt(totalCell.innerHTML) + project.ProjectTime
							}
						}
					}
					var totalCells = document.getElementsByClassName('project-total')
					var totalWorkHours = 0
					for (let i=0; i<totalCells.length;i++) {
						var cell = totalCells[i]
						var projectTime = parseInt(cell.innerHTML)
						totalWorkHours += projectTime
						cell.innerHTML = formatMinutesToHHMM(projectTime)
						document.getElementById('totalWorkHours').innerHTML = formatMinutesToHHMM(totalWorkHours)
					}
				this.toggleLeave()
			  	
		}
		this.Refresh = function(SDTProjects ,SDTEmployeeProjectHoursCollection ) {

					this.SDTProjects = SDTProjects
					this.SDTEmployeeProjectHoursCollection = SDTEmployeeProjectHoursCollection
					this.show()
				
		}
		this.toggleLeave = function() {

					var elements = document.getElementsByClassName("leave");
					
					for (var i = 0; i < elements.length; i++) {
						
						if (this.ShowLeaveTotal=='true') {
							console.log(typeof this.ShowLeaveTotal)
							elements[i].classList.remove("hidden");
						} else {
							elements[i].classList.add("hidden");
						}
					}
				
		}


		this.onClickHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 this.SDTProjectsCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.SDTEmployeeProjectHoursCollectionCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 this.ProjectHoursCurrentIndex = (parseInt($(target).attr('data-items-index'), 10) || 1);  
				 
				 
				 
			}

			if (this.Click) {
				this.Click();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}